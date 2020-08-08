using ChatterBot.Core.Data;
using ChatterBot.Core.Interfaces;
using ChatterBot.Core.State;
using System.ComponentModel;

namespace ChatterBot.Core.SimpleCommands
{
    public class SimpleCommandsPlugin : IPlugin
    {
        private readonly IDataStore _dataStore;
        private readonly CommandsSet _commandsSet;

        public SimpleCommandsPlugin(IDataStore dataStore, CommandsSet commandsSet)
        {
            _dataStore = dataStore;
            _commandsSet = commandsSet;
        }

        public void Initialize()
        {
            _commandsSet.Initialize(_dataStore.GetCommands());

            _commandsSet.CustomCommands.ListChanged += CustomCommandsOnListChanged;
        }

        private void CustomCommandsOnListChanged(object sender, ListChangedEventArgs e)
        {
            _dataStore.SaveCommands(_commandsSet.CustomCommands);
        }
    }
}