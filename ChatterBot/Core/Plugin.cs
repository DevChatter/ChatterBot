using System;

namespace ChatterBot.Core
{
    public class Plugin : BaseBindable
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Location { get; set; }
        public PluginRuntime PluginRuntime { get; set; }
        public bool Enabled { get; set; }
    }
}