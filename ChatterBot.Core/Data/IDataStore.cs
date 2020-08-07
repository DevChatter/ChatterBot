using ChatterBot.Core.Auth;
using System.Collections.Generic;

namespace ChatterBot.Core.Data
{
    public interface IDataStore
    {
        void EnsureSchema();
        List<TwitchCredentials> GetCredentials(); // TODO: Less-Specific
        void SaveCredentials(IEnumerable<TwitchCredentials> credentials); // TODO: Less-Specific
    }
}