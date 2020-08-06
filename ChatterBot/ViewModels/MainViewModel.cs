using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ChatterBot.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private ObservableCollection<MenuItemViewModel> _menuOptionItems;
        private AccountsWindow _settingsWindow;
        private readonly AccountsViewModel _accountsViewModel;

        public MainViewModel(AccountsViewModel accountsViewModel,
            TerminalViewModel terminalViewModel,
            CommandsViewModel commandsViewModel,
            PluginViewModel pluginViewModel,
            AboutViewModel aboutViewModel,
            SettingsViewModel settingsViewModel)
        {
            _accountsViewModel = accountsViewModel;
            ShowAccountsWindowCommand = new ActionCommand(ShowAccountsWindow);
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                terminalViewModel,
                commandsViewModel,
                pluginViewModel,
            };
            MenuOptionItems = new ObservableCollection<MenuItemViewModel>
            {
                aboutViewModel,
                settingsViewModel,
            };

        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ObservableCollection<MenuItemViewModel> MenuOptionItems
        {
            get => _menuOptionItems;
            set => SetProperty(ref _menuOptionItems, value);
        }

        public ICommand ShowAccountsWindowCommand { get; set; }

        private void ShowAccountsWindow()
        {
            if (_settingsWindow != null)
            {
                _settingsWindow.Activate();
                return;
            }

            _settingsWindow = new AccountsWindow(_accountsViewModel);
            _settingsWindow.Owner = Application.Current.MainWindow;
            _settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _settingsWindow.Closed += (o, args) => _settingsWindow = null;
            _settingsWindow.Show();
        }
    }
}
