using ChatterBot.Data;
using ChatterBot.Domain.State;
using ChatterBot.FileSystem;
using System.Collections.Generic;
using System.Linq;

namespace ChatterBot.Domain.Plugins
{
    internal class PluginInitialization : IPluginInitialization
    {
        private readonly IDataStore _dataStore;
        private readonly IDirectoryReader _directoryReader;
        private readonly IPluginSet _pluginSet;

        public PluginInitialization(IDataStore dataStore,
            IDirectoryReader directoryReader,
            IPluginSet pluginSet)
        {
            _dataStore = dataStore;
            _directoryReader = directoryReader;
            _pluginSet = pluginSet;
        }

        public void Initialize()
        {
            List<PluginInfo> pluginInfos = _dataStore.GetEntities<PluginInfo>();

            List<string> pluginFolders = _directoryReader.ReadPluginsFolder();

            List<PluginInfo> matchedPlugins = RegisterCompletePlugins(pluginInfos, pluginFolders);

            CreateRecordsForNewPlugins(pluginFolders, matchedPlugins);

            FlagMissingPlugins(pluginInfos, matchedPlugins);
        }

        private void FlagMissingPlugins(List<PluginInfo> pluginInfos, List<PluginInfo> matchedPlugins)
        {
            foreach (var pluginInfo in pluginInfos.Except(matchedPlugins))
            {
                pluginInfo.Status = PluginStatuses.Missing;
                _pluginSet.Register(pluginInfo);
            }
        }

        private void CreateRecordsForNewPlugins(List<string> pluginFolders, List<PluginInfo> matchedPlugins)
        {
            // TODO: Check for Metadata file.

            foreach (string pluginFolder in pluginFolders.Except(matchedPlugins.Select(x => x.Location)))
            {
                var info = new PluginInfo
                {
                    Name = pluginFolder,
                    Location = pluginFolder,
                    Version = "1.0.0.0",
                    Enabled = false
                };
                _pluginSet.Register(info);
            }
        }

        private List<PluginInfo> RegisterCompletePlugins(List<PluginInfo> pluginInfos, List<string> pluginFolders)
        {
            // TODO: Match these on more than just folder name is consistent.
            var matchedPlugins = pluginInfos.Join(pluginFolders,
                info => info.Location,
                folder => folder,
                (info, folder) => info).ToList();

            foreach (PluginInfo pluginInfo in matchedPlugins)
            {
                _pluginSet.Register(pluginInfo);
            }

            return matchedPlugins;
        }
    }
}