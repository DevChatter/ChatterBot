using ChatterBot.Domain.Plugins;
using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;

namespace ChatterBot.UI.ViewModels
{
    public class PluginViewModel : MenuItemViewModel
    {
        public ObservableCollection<PluginInfo> Plugins { get; set; }

        public PluginViewModel()
            : base(new PackIconMaterial { Kind = PackIconMaterialKind.Puzzle }, "Plugins",
                "Custom Plugins", new PluginView())
        {
            Plugins = new ObservableCollection<PluginInfo>
            {
                new PluginInfo { Name = "Wasteful Game", Location = "\\WastefulGame\\",
                    Enabled = true, PluginRuntime = PluginRuntime.ChatterPlugin, Version = "1.0.0.0"},
                new PluginInfo { Name = "DevChatter Arcade", Location = "\\DevChatterArcade\\",
                    Enabled = true, PluginRuntime = PluginRuntime.ChatterPlugin, Version = "1.0.0.0"},
                new PluginInfo { Name = "Jedi/Sith Detector", Location = "\\JediSithDetector\\",
                    Enabled = true, PluginRuntime = PluginRuntime.PythonScript, Version = "1.0.0.0"},
            };
        }
    }
}