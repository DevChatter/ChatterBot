using ChatterBot.Core;
using ChatterBot.Core.Interfaces;
using MahApps.Metro.Controls;

namespace ChatterBot.ViewModels
{
    public abstract class MenuItemViewModel
        : BaseBindable, IHamburgerMenuItemBase, IMenuItemViewModel
    {
        private bool _isVisible = true;

        protected MenuItemViewModel(object icon, object label, object toolTip,
            object content, bool isOption = false)
        {
            Icon = icon;
            Label = label;
            ToolTip = toolTip;
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
