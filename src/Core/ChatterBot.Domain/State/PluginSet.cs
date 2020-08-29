using ChatterBot.Domain.Plugins;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    internal class PluginSet : BaseSet<PluginInfo>, IPluginSet
    {
        public BindingList<PluginInfo> Plugins => Items;
    }
}