using System;

namespace ChatterBot.Core
{
    public class Plugin : BaseBindable
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public PluginRuntime PluginRuntime { get; set; }
        public bool Enabled { get; set; }
    }
}