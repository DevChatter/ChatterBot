using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        private ObservableCollection<TwitchAccountViewModel> _menuItems;

        public AccountsViewModel(TwitchBotViewModel botViewModel, TwitchStreamerViewModel streamerViewModel)
        {
            MenuItems = new ObservableCollection<TwitchAccountViewModel>
            {
                botViewModel,
                streamerViewModel,
            };
        }

        public ObservableCollection<TwitchAccountViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }
    }
}