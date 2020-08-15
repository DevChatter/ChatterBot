using ChatterBot.Domain.Plugins;
using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    internal class PluginSet : BaseSet<PluginInfo>, IPluginSet
    {
        public ICollection<PluginInfo> Plugins => Items;
    }
}