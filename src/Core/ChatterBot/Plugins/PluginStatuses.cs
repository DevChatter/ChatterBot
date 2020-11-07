namespace ChatterBot.Plugins
{
    public enum PluginStatuses
    {
        New = 0,
        Enabled = 1, // Only state where it is ON
        Disabled = 2,
        Missing = 3,
        Error = 4,
    }
}