using ChatterBot.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Core.State
{
    public class MainMenuItemsSet
    {
        public BindingList<IMenuItemViewModel> MenuItems { get; private set; }
        public BindingList<IMenuItemViewModel> MenuOptionItems { get; private set; }

        public void Initialize(IEnumerable<IMenuItemViewModel> menuItems, IEnumerable<IMenuItemViewModel> menuOptionItems)
        {
            MenuItems = new BindingList<IMenuItemViewModel>(menuItems.ToList());
            MenuOptionItems = new BindingList<IMenuItemViewModel>(menuOptionItems.ToList());
        }
    }
}
