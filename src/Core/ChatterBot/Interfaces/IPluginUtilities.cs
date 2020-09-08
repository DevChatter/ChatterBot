using ChatterBot.Data;
using ChatterBot.State;

namespace ChatterBot.Interfaces
{
    public interface IPluginUtilities
    {
        IMainMenuItemsSet MainMenuItemsSet { get; }
        IDataStore DataStore { get; }
        IMessageHandler MessageHandler { get; }
        IMessageSender MessageSender { get; }
    }
}