using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;
using ChatterBot.Twitch;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    internal class SimpleCommandsPlugin : IPlugin
    {
        private readonly IDataStore _dataStore;
        private readonly IMessageHandler _messageHandler;
        private readonly IMessageSender _messageSender;
        private readonly IMainMenuItemsSet _menuItemsSet;
        private readonly ICommandsSet _commandsSet;
        private readonly CommandsViewModel _commandsViewModel;

        public SimpleCommandsPlugin(IDataStore dataStore, IMessageHandler messageHandler,
            IMessageSender messageSender, IMainMenuItemsSet menuItemsSet, ICommandsSet commandsSet)
        {
            _dataStore = dataStore;
            _messageHandler = messageHandler;
            _messageSender = messageSender;
            _menuItemsSet = menuItemsSet;
            _commandsSet = commandsSet;
            _commandsViewModel = new CommandsViewModel(_commandsSet);
        }

        public void Enable()
        {
            _menuItemsSet.MenuItems.Add(_commandsViewModel);

            _commandsSet.CustomCommands.ListChanged += CustomCommandsOnListChanged;

            _messageHandler.MessageReceived += MessageHandlerOnMessageReceived;
        }

        private void MessageHandlerOnMessageReceived(object? sender, MessageReceivedEventArgs e)
        {
            IEnumerable<CustomCommand> toRun = _commandsSet.GetCommandsToRun(e.ChatMessage);

            foreach (CustomCommand command in toRun)
            {
                _messageSender.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Text);
            }
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