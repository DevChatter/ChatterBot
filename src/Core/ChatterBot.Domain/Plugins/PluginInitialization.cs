using ChatterBot.Data;
using ChatterBot.Domain.State;
using ChatterBot.FileSystem;
using ChatterBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChatterBot.Domain.Plugins
{
    internal class PluginInitialization : IPluginInitialization
    {
        private readonly IDirectoryReader _directoryReader;
        private readonly IPluginSet _pluginSet;

        public PluginInitialization(IDirectoryReader directoryReader,
            IPluginSet pluginSet)
        {
            _directoryReader = directoryReader;
            _pluginSet = pluginSet;
        }

        public void Initialize()
        {
            List<string> pluginFolders = _directoryReader.ReadPluginsFolder();

            List<PluginInfo> matchedPlugins = FindMatchedPlugins(pluginFolders);

            CreateRecordsForNewPlugins(pluginFolders, matchedPlugins);

            FlagMissingPlugins(matchedPlugins);

            StartEnabledPlugins(matchedPlugins);
        }

        private void StartEnabledPlugins(List<PluginInfo> plugins)
        {
            Type pluginInterface = typeof(IPlugin);
            Type pluginFactoryInterface = typeof(IPluginFactory);

            foreach (PluginInfo pluginInfo in plugins.Where(x => x.Enabled))
            {
                Assembly assembly = Assembly.LoadFrom(pluginInfo.Location);

                var factoryTypes = assembly.GetTypes()
                    .Where(x => !x.IsAbstract && pluginFactoryInterface.IsAssignableFrom(x))
                    .ToArray();

                if (factoryTypes.Length == 1)
                {
                    IPluginFactory startupObject = CreateFactoryObject(factoryTypes.Single());
                    startupObject.CreatePlugin(null); // TODO: Pass in the Utils from IoC
                    // TODO: See if we can connect the plugin with the plugininfo to do Enable/Disable
                }
                else
                {
                    var instanceTypes = assembly.GetTypes()
                        .Where(x => !x.IsAbstract && pluginInterface.IsAssignableFrom(x))
                        .ToArray();

                    // TODO: Extract this!
                    if (instanceTypes.Length < 1)
                    {
                        // TODO: Yell that we didn't find an init class.
                    }
                    else if (instanceTypes.Length > 1)
                    {
                        // TODO: Yell that we found more than one init class.
                    }
                    else
                    {
                        IPlugin startupObject = CreateStartUpObject(instanceTypes.Single());
                    }
                }
            }

            //IEnumerable<IPlugin> plugins = provider.GetServices<IPlugin>();
            //foreach (IPlugin plugin in plugins)
            //{
            //    plugin.Initialize();
            //}

        }

        private static IPluginFactory CreateFactoryObject(Type factoryType)
        {
            try
            {
                return (IPluginFactory)Activator.CreateInstance(factoryType)!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static IPlugin CreateStartUpObject(Type startupType)
        {
            try
            {
                return (IPlugin)Activator.CreateInstance(startupType)!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void FlagMissingPlugins(List<PluginInfo> matchedPlugins)
        {
            foreach (var pluginInfo in _pluginSet.Plugins.Except(matchedPlugins))
            {
                pluginInfo.Status = PluginStatuses.Missing;
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
                    PluginRuntime = PluginRuntime.Unknown,
                    Version = "1.0.0.0",
                    Enabled = false
                };
                _pluginSet.Register(info);
            }
        }

        private List<PluginInfo> FindMatchedPlugins(List<string> pluginFolders)
        {
            // TODO: Match these on more than just folder name is consistent.
            var matchedPlugins = _pluginSet.Plugins.Join(pluginFolders,
                info => info.Location,
                folder => folder,
                (info, folder) => info).ToList();

            return matchedPlugins;
        }
    }
}