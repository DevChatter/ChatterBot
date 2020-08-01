using MahApps.Metro.IconPacks;
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

        public MainViewModel()
        {
            _accountsViewModel = new AccountsViewModel();
            CreateMenuItems();
            ShowAccountsWindowCommand = new ActionCommand(ShowAccountsWindow);
        }

        public void CreateMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new TerminalViewModel(this)
                {
                    Icon = new PackIconMaterialDesign {Kind = PackIconMaterialDesignKind.Chat},
                    Label = "Chat",
                    ToolTip = "Console and Chat"
                },
                new CommandsViewModel(this)
                {
                    Icon = new PackIconFontAwesome {Kind = PackIconFontAwesomeKind.ExclamationSolid},
                    Label = "Commands",
                    ToolTip = "Custom Commands"
                },
                new PluginViewModel(this)
                {
                    Icon = new PackIconMaterial {Kind = PackIconMaterialKind.Puzzle},
                    Label = "Plugins",
                    ToolTip = "Custom Plugins"
                },
            };

            MenuOptionItems = new ObservableCollection<MenuItemViewModel>
            {
                new AboutViewModel(this)
                {
                    Icon = new PackIconMaterial {Kind = PackIconMaterialKind.Help},
                    Label = "About",
                    ToolTip = "Information About ChatterBot"
                },
                new SettingsViewModel(this)
                {
                    Icon = new PackIconMaterial {Kind = PackIconMaterialKind.Cog},
                    Label = "Settings",
                    ToolTip = "Application Settings"
                },
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
