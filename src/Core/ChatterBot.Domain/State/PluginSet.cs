using ChatterBot.Data;
using ChatterBot.Domain.Plugins;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    internal class PluginSet : BaseSet<PluginInfo>, IPluginSet
    {
        public PluginSet(IDataStore dataStore)
        {
            Items = new BindingList<PluginInfo>(dataStore.GetEntities<PluginInfo>());
        }

        public BindingList<PluginInfo> Plugins => Items;
    }
}