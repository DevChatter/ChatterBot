using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;

        public AccountsViewModel(TwitchBotViewModel botViewModel, TwitchStreamerViewModel streamerViewModel)
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                botViewModel,
                streamerViewModel,
            };
        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }
    }
}