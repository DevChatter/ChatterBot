using ChatterBot.Core.Auth;
using ChatterBot.Core.Config;
using ChatterBot.Core.Data;
using LiteDB;
using System.Collections.Generic;

namespace ChatterBot.Infra.LiteDb
{
    public class DataStore : IDataStore
    {
        private readonly ApplicationSettings _appSettings;

        public DataStore(ApplicationSettings appSettings)
        {
            _appSettings = appSettings;
        }
        
        public void EnsureSchema()
        {
            BsonMapper.Global.Entity<TwitchCredentials>().Id(x => x.AuthType);

            using (var db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                // Create Collection if it doesn't exist.
                var col = db.GetCollection<TwitchCredentials>(nameof(TwitchCredentials));
            }
        }

        public List<TwitchCredentials> GetCredentials()
        {
            using (var db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                var col = db.GetCollection<TwitchCredentials>(nameof(TwitchCredentials));

                return col.Query().ToList();
            }
        }

        public void SaveCredentials(IEnumerable<TwitchCredentials> credentials)
        {
            using (var db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                var col = db.GetCollection<TwitchCredentials>(nameof(TwitchCredentials));

                col.Upsert(credentials);
            }
        }
    }
}
