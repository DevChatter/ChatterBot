using ChatterBot.Views;
using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
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