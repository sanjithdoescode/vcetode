using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VCETODE.Core;

namespace VCETODE.Plugins
{
    /// <summary>
    /// Loads and manages VCETODE plugins dynamically from a specified directory.
    /// </summary>
    public class PluginManager
    {
        public List<IVCETODEPlugin> Plugins { get; private set; } = new List<IVCETODEPlugin>();

        public void LoadPlugins(string pluginsDirectory, PluginContext context)
        {
            if (!Directory.Exists(pluginsDirectory))
                return;

            foreach (var dll in Directory.GetFiles(pluginsDirectory, "*.dll"))
            {
                try
                {
                    Assembly asm = Assembly.LoadFrom(dll);
                    var pluginTypes = asm.GetTypes().Where(t => typeof(IVCETODEPlugin).IsAssignableFrom(t) &&
                                                                !t.IsInterface && !t.IsAbstract);
                    foreach (var type in pluginTypes)
                    {
                        IVCETODEPlugin plugin = (IVCETODEPlugin)Activator.CreateInstance(type);
                        plugin.Initialize(context);
                        Plugins.Add(plugin);
                        Logger.LogInfo($"Loaded plugin: {plugin.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error loading plugin from {dll}", ex);
                }
            }
        }

        public void ExecuteAll()
        {
            foreach (var plugin in Plugins)
            {
                try
                {
                    plugin.Execute();
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error executing plugin: {plugin.Name}", ex);
                }
            }
        }
    }
}
