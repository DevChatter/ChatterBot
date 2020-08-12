using ChatterBot.Auth;
using ChatterBot.Config;
using ChatterBot.Data;
using LiteDB;
using System.Collections.Generic;

namespace ChatterBot.Infra.LiteDb
{
    internal class DataStore : IDataStore
    {
        private readonly ApplicationSettings _appSettings;

        public DataStore(ApplicationSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void EnsureSchema()
        {
            BsonMapper.Global.Entity<TwitchCredentials>().Id(x => x.AuthType);

            using (LiteDatabase db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                // Create Collection if it doesn't exist.
                _ = db.GetCollection<TwitchCredentials>(nameof(TwitchCredentials));
            }
        }

        public List<TEntity> GetEntities<TEntity>()
        {
            using (LiteDatabase db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                ILiteCollection<TEntity> col = db.GetCollection<TEntity>(typeof(TEntity).Name);

                return col.Query().ToList();
            }
        }

        public void SaveEntities<TEntity>(IEnumerable<TEntity> entities)
        {
            using (LiteDatabase db = new LiteDatabase(_appSettings.LightDbConnection))
            {
                ILiteCollection<TEntity> col = db.GetCollection<TEntity>(typeof(TEntity).Name);

                col.Upsert(entities);
            }
        }
    }
}