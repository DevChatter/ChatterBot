using ChatterBot.Core.Interfaces;
using ChatterBot.ViewModels;
using MahApps.Metro.Controls;
using System.Linq;

namespace ChatterBot
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
            ChangeView(mainViewModel.MenuItems.First());
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ChangeView((IMenuItemViewModel)e.ClickedItem);
        }

        private void ChangeView(IMenuItemViewModel menuItem)
        {
            HamburgerMenu.Content = menuItem.Content;
            HamburgerMenu.IsPaneOpen = false;
        }
    }
}
