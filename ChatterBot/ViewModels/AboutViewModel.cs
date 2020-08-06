using MahApps.Metro.IconPacks;

namespace ChatterBot.ViewModels
{
    public class AboutViewModel : MenuItemViewModel
    {
        public AboutViewModel()
        {
            Icon = new PackIconMaterial { Kind = PackIconMaterialKind.Help };
            Label = "About";
            ToolTip = "Information About ChatterBot";
        }
    }
}
