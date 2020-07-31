using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;

        public AccountsViewModel()
        {
            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new TwitchBotViewModel(this)
                {
                    Icon = new PackIconMaterial {Kind = PackIconMaterialKind.Robot},
                    Label = "Bot Account",
                    ToolTip = "Twitch Bot Account Settings"
                },
                new TwitchStreamerViewModel(this)
                {
                    Icon = new PackIconOcticons {Kind = PackIconOcticonsKind.DeviceCameraVideo},
                    Label = "Streamer Account",
                    ToolTip = "Twitch Stream Account Settings"
                },
            };
        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }
    }
}