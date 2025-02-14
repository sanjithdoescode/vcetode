namespace VCETODE.Plugins
{
    /// <summary>
    /// Interface that all VCETODE plugins must implement.
    /// </summary>
    public interface IVCETODEPlugin
    {
        string Name { get; }
        void Initialize(PluginContext context);
        void Execute();
    }
}
