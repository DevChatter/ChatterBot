using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private ObservableCollection<MenuItemViewModel> _menuOptionItems;

        public MainViewModel()
        {
            this.CreateMenuItems();
        }

        public void CreateMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new TerminalViewModel(this)
                {
                    Icon = new PackIconOcticons {Kind = PackIconOcticonsKind.Terminal},
                    Label = "Terminal",
                    ToolTip = "Console and Chat"
                },
                new CommandsViewModel(this)
                {
                    Icon = new PackIconFontAwesome {Kind = PackIconFontAwesomeKind.ExclamationSolid},
                    Label = "Commands",
                    ToolTip = "Custom Commands"
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
    }
}