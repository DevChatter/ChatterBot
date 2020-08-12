using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;

namespace ChatterBot.UI.ViewModels
{
    public class SettingsViewModel : MenuItemViewModel
    {
        public SettingsViewModel()
            : base(new PackIconMaterial { Kind = PackIconMaterialKind.Cog },
                "Settings", "Application Settings", new AppSettingsView(), true)
        {
        }
    }
}