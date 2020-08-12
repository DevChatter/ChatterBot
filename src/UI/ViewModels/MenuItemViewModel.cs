using ChatterBot.Interfaces;
using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace ChatterBot.UI.ViewModels
{
    public abstract class MenuItemViewModel
        : BaseBindable, IHamburgerMenuItemBase, IMenuItemViewModel
    {
        private bool _isVisible = true;

        protected MenuItemViewModel(object icon, object label, object toolTip,
            UserControl content, bool isOption = false)
        {
            Icon = icon;
            Label = label;
            ToolTip = toolTip;
            content.DataContext = this;
            Content = content;
            IsOption = isOption;
        }

        public object? Icon { get; }
        public object? Label { get; }
        public object? ToolTip { get; }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public bool IsOption { get; }
        public object? Content { get; }
    }
}
