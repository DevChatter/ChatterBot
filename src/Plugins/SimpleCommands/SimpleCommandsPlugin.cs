using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    internal class SimpleCommandsPlugin : IPlugin
    {
        private readonly IDataStore _dataStore;
        private readonly ICommandsSet _commandsSet;
        private readonly IMainMenuItemsSet _menuItemsSet;

        public SimpleCommandsPlugin(IDataStore dataStore,
            ICommandsSet commandsSet, IMainMenuItemsSet menuItemsSet)
        {
            _dataStore = dataStore;
            _commandsSet = commandsSet;
            _menuItemsSet = menuItemsSet;
        }

        public void Initialize()
        {
            _commandsSet.Initialize(_dataStore.GetEntities<CustomCommand>());

            _menuItemsSet.MenuItems.Add(new CommandsViewModel(_commandsSet)); // TODO: Move to Enable()

            _commandsSet.CustomCommands.ListChanged += CustomCommandsOnListChanged; // TODO: Move to Enable()
        }

        private void CustomCommandsOnListChanged(object sender, ListChangedEventArgs e)
        {
            var toSave = _commandsSet.CustomCommands.Where(x => string.IsNullOrEmpty(x.Error));
            _dataStore.SaveEntities(toSave);
        }
    }
}