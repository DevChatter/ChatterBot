using ChatterBot.Data;
using ChatterBot.Domain.Plugins;
using ChatterBot.Domain.State;
using ChatterBot.FileSystem;
using ChatterBot.Tests.Builders;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChatterBot.Tests.Domain.Plugins
{
    public class PluginInitialization_Should : BaseTestFixture
    {
        private readonly ServiceProvider _provider;
        private readonly Mock<IDataStore> _dataStore;
        private readonly Mock<IDirectoryReader> _directoryReader;
        private readonly IPluginInitialization _pluginInit;
        private readonly IPluginSet _pluginSet;

        public PluginInitialization_Should()
        {
            _dataStore = new Mock<IDataStore>();
            _directoryReader = new Mock<IDirectoryReader>();

            _provider = SetUpServices(x =>
            {
                x.AddSingleton(_dataStore.Object);
                x.AddSingleton(_directoryReader.Object);
                x.AddDomain(FakeSettingsBuilder.New().WithTestData().Build());
            });

            _pluginInit = _provider.GetRequiredService<IPluginInitialization>();
            _pluginSet = _provider.GetRequiredService<IPluginSet>();
        }

        [Fact]
        public void SetNoPluginData_GivenEmptyFolderAndDatabase()
        {
            SetReturnValues(new List<PluginInfo>(), new List<string>());

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().BeEmpty();
        }

        [Theory]
        [InlineData("SimpleCommands")]
        [InlineData("SimpleCommands", "ChatGames")]
        [InlineData("SimpleCommands", "ChatGames", "FartBot")]
        public void CreatesPluginInfo_GivenFolderDataAndEmptyDb(params string[] pluginNames)
        {
            SetReturnValues(new List<PluginInfo>(), pluginNames.ToList());

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().HaveCount(pluginNames.Length);

            foreach (string pluginName in pluginNames)
            {
                _pluginSet.Plugins.Should()
                    .ContainSingle(x => !x.Enabled
                                        && x.Name == pluginName
                                        && x.Location == pluginName);
            }
        }

        [Fact]
        public void AddsPluginInfoAsMissing_GivenDatabaseDataAndEmptyFolder()
        {
            var pluginInfo = new PluginInfo();
            SetReturnValues(new List<PluginInfo> { pluginInfo }, new List<string>());

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().ContainSingle();
            _pluginSet.Plugins.Should().Contain(pluginInfo);
            _pluginSet.Plugins.Single().Status.Should().Be(PluginStatuses.Missing);
        }

        [Fact]
        public void IncludePlugins_GivenPluginInBothFolderAndDatabase()
        {
            string pluginName = "SimpleCommands";
            PluginStatuses status = PluginStatuses.Enabled;
            var pluginInfo = new PluginInfo { Name = pluginName, Location = pluginName, Status = status };
            SetReturnValues(new List<PluginInfo> { pluginInfo }, new List<string> { pluginName });

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().ContainSingle();
            _pluginSet.Plugins.Should().Contain(pluginInfo);
            _pluginSet.Plugins.Single().Status.Should().Be(status);
        }

        private void SetReturnValues(List<PluginInfo> pluginInfos, List<string> fileNames)
        {
            _dataStore.Setup(x => x.GetEntities<PluginInfo>())
                .Returns(pluginInfos)
                .Verifiable();
            _directoryReader.Setup(x => x.ReadPluginsFolder())
                .Returns(fileNames)
                .Verifiable();
        }
    }
}