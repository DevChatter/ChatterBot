using ChatterBot.Data;
using ChatterBot.Domain.Plugins;
using ChatterBot.Domain.State;
using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;
using System.ComponentModel;

namespace ChatterBot.UI.ViewModels
{
    public class PluginViewModel : MenuItemViewModel
    {
        private readonly IPluginSet _pluginSet;
        private readonly IDataStore _dataStore;

        public BindingList<PluginInfo> Plugins => _pluginSet.Plugins;

        public PluginViewModel(IPluginSet pluginSet, IDataStore dataStore)
            : base(new PackIconMaterial { Kind = PackIconMaterialKind.Puzzle }, "Plugins",
                "Custom Plugins", new PluginView())
        {
            _pluginSet = pluginSet;
            _dataStore = dataStore;

            _pluginSet.Plugins.ListChanged += PluginsOnListChanged;
        }

        private void PluginsOnListChanged(object sender, ListChangedEventArgs e)
        {
            _dataStore.SaveEntities(_pluginSet.Plugins);
        }
    }
}
