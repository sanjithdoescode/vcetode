using VCETODE.Core;

namespace VCETODE.Plugins
{
    /// <summary>
    /// A sample plugin that logs a hello-world message.
    /// </summary>
    public class SamplePlugin : IVCETODEPlugin
    {
        public string Name => "Sample Plugin - Hello World";

        public void Initialize(PluginContext context)
        {
            // Initialization logic, e.g. registering commands with the editor.
            Logger.LogInfo("SamplePlugin initialized.");
        }

        public void Execute()
        {
            // Execution logic; here we simply log a message.
            Logger.LogInfo("SamplePlugin executed: Hello World!");
        }
    }
}
