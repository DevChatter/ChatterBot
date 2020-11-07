using ChatterBot.Data;
using ChatterBot.Plugins;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    internal class PluginSet : BaseSet<PluginInfo>, IPluginSet
    {
        public PluginSet(IDataStore dataStore)
            : base(dataStore.GetEntities<PluginInfo>())
        {
        }

        public BindingList<PluginInfo> Plugins => Items;
    }
}