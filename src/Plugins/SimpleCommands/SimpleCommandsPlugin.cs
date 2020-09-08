﻿using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    internal class SimpleCommandsPlugin : IPlugin
    {
        private readonly IDataStore _dataStore;
        private readonly IMainMenuItemsSet _menuItemsSet;
        private readonly ICommandsSet _commandsSet;
        private readonly CommandsViewModel _commandsViewModel;

        public SimpleCommandsPlugin(IDataStore dataStore,
            IMainMenuItemsSet menuItemsSet, ICommandsSet commandsSet)
        {
            _dataStore = dataStore;
            _menuItemsSet = menuItemsSet;
            _commandsSet = commandsSet;
            _commandsViewModel = new CommandsViewModel(_commandsSet);
        }

        public void Enable()
        {
            _menuItemsSet.MenuItems.Add(_commandsViewModel);

            _commandsSet.CustomCommands.ListChanged += CustomCommandsOnListChanged;
        }

        public void Disable()
        {
            _menuItemsSet.MenuItems.Remove(_commandsViewModel);

            _commandsSet.CustomCommands.ListChanged -= CustomCommandsOnListChanged;
        }

        private void CustomCommandsOnListChanged(object sender, ListChangedEventArgs e)
        {
            var toSave = _commandsSet.CustomCommands.Where(x => string.IsNullOrEmpty(x.Error));
            _dataStore.SaveEntities(toSave);
        }

    }
}