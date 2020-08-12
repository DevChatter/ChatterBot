using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;
using Microsoft.Xaml.Behaviors.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ChatterBot.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private AccountsWindow? _settingsWindow;
        private readonly AccountsViewModel _accountsViewModel;
        private readonly IMainMenuItemsSet _mainMenuItemsSet;
        private readonly IDataStore _dataStore;

        public MainViewModel(AccountsViewModel accountsViewModel,
            IMainMenuItemsSet mainMenuItemsSet,
            IDataStore dataStore)
        {
            _accountsViewModel = accountsViewModel;
            _mainMenuItemsSet = mainMenuItemsSet;
            _dataStore = dataStore;
            ShowAccountsWindowCommand = new ActionCommand(ShowAccountsWindow);
        }

        public BindingList<IMenuItemViewModel> MenuItems => _mainMenuItemsSet.MenuItems;

        public BindingList<IMenuItemViewModel> MenuOptionItems => _mainMenuItemsSet.MenuOptionItems;

        public ICommand ShowAccountsWindowCommand { get; set; }

        private void ShowAccountsWindow()
        {
            if (_settingsWindow != null)
            {
                _settingsWindow.Activate();
                return;
            }

            _settingsWindow = new AccountsWindow(_accountsViewModel, _dataStore);
            _settingsWindow.Owner = Application.Current.MainWindow;
            _settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _settingsWindow.Closed += (o, args) => _settingsWindow = null;
            _settingsWindow.Show();
        }
    }
}
