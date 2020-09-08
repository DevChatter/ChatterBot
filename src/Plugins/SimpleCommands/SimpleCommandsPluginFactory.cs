using ChatterBot.Interfaces;

namespace ChatterBot.Plugins.SimpleCommands
{
    internal class SimpleCommandsPluginFactory : IPluginFactory
    {
        public IPlugin CreatePlugin(IPluginUtilities utilities)
        {
            var commands = utilities.DataStore.GetEntities<CustomCommand>();
            var commandsSet = new CommandsSet(commands);

            return new SimpleCommandsPlugin(utilities.DataStore, utilities.MessageHandler,
                utilities.MessageSender, utilities.MainMenuItemsSet, commandsSet);
        }
    }
}