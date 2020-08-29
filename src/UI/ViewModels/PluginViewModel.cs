using ChatterBot.Domain.Plugins;
using ChatterBot.Domain.State;
using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ChatterBot.UI.ViewModels
{
    public class PluginViewModel : MenuItemViewModel
    {
        private readonly IPluginSet _pluginSet;

        public BindingList<PluginInfo> Plugins => _pluginSet.Plugins;

        public PluginViewModel(IPluginSet pluginSet)
            : base(new PackIconMaterial { Kind = PackIconMaterialKind.Puzzle }, "Plugins",
                "Custom Plugins", new PluginView())
        {
            _pluginSet = pluginSet;
        }
    }
}