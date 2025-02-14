namespace VCETODE.Plugins
{
    /// <summary>
    /// Provides context and services to plugins.
    /// Extend with more properties (Editor, Terminal, etc.) as needed.
    /// </summary>
    public class PluginContext
    {
        public object Editor { get; set; }
        public object Terminal { get; set; }
        // Additional services can be injected here.
    }
}
