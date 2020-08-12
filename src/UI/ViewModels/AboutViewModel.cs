using ChatterBot.UI.Views;
using MahApps.Metro.IconPacks;

namespace ChatterBot.UI.ViewModels
{
    public class AboutViewModel : MenuItemViewModel
    {
        public AboutViewModel()
            : base(new PackIconMaterial { Kind = PackIconMaterialKind.Help },
                "About", "About the Bot", new AboutView(), true)
        {
        }
    }
}
