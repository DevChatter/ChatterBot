using ChatterBot.Core.Auth;
using ChatterBot.Core.SimpleCommands;
using System.Collections.Generic;

namespace ChatterBot.Core.Data
{
    public interface IDataStore
    {
        void EnsureSchema();
        List<TwitchCredentials> GetCredentials(); // TODO: Less-Specific
        void SaveCredentials(IEnumerable<TwitchCredentials> credentials); // TODO: Less-Specific
        List<CustomCommand> GetCommands(); // TODO: Less-Specific
        void SaveCommands(IEnumerable<CustomCommand> commands); // TODO: Less-Specific
    }
}