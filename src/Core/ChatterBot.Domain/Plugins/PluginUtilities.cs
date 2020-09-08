using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;

namespace ChatterBot.Domain.Plugins
{
    public class PluginUtilities : IPluginUtilities
    {
        public PluginUtilities(IMainMenuItemsSet mainMenuItemsSet,
            IDataStore dataStore, IMessageHandler messageHandler,
            IMessageSender messageSender)
        {
            MainMenuItemsSet = mainMenuItemsSet;
            DataStore = dataStore;
            MessageHandler = messageHandler;
            MessageSender = messageSender;
        }

        public IMainMenuItemsSet MainMenuItemsSet { get; }
        public IDataStore DataStore { get; }
        public IMessageHandler MessageHandler { get; }
        public IMessageSender MessageSender { get; }
    }
}