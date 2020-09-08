using ChatterBot.Data;
using ChatterBot.Interfaces;
using ChatterBot.State;

namespace ChatterBot.Domain.Plugins
{
    public class PluginUtilities : IPluginUtilities
    {
        public PluginUtilities(IMainMenuItemsSet mainMenuItemsSet, IDataStore dataStore)
        {
            MainMenuItemsSet = mainMenuItemsSet;
            DataStore = dataStore;
        }

        public IMainMenuItemsSet MainMenuItemsSet { get; }
        public IDataStore DataStore { get; }
    }
}