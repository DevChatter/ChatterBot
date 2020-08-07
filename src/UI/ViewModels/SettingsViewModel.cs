using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class SettingsViewModel : MenuItemViewModel
    {
        public SettingsViewModel()
        {
            Icon = new PackIconMaterial { Kind = PackIconMaterialKind.Cog };
            Label = "Settings";
            ToolTip = "Application Settings";
        }
    }
}