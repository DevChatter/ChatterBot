using ChatterBot.Core.Interfaces;
using ChatterBot.Core.State;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Domain.State
{
    internal class MainMenuItemsSet : IMainMenuItemsSet
    {
        public BindingList<IMenuItemViewModel> MenuItems { get; private set; } = new BindingList<IMenuItemViewModel>();
        public BindingList<IMenuItemViewModel> MenuOptionItems { get; private set; } = new BindingList<IMenuItemViewModel>();

        public void Initialize(IEnumerable<IMenuItemViewModel> menuItems, IEnumerable<IMenuItemViewModel> menuOptionItems)
        {
            MenuItems = new BindingList<IMenuItemViewModel>(menuItems.ToList());
            MenuOptionItems = new BindingList<IMenuItemViewModel>(menuOptionItems.ToList());
        }
    }
}