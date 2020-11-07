using ChatterBot.Data;
using ChatterBot.Domain.Plugins;
using ChatterBot.Domain.State;
using ChatterBot.FileSystem;
using ChatterBot.Interfaces;
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
        private readonly Mock<IDataStore> _dataStore;
        private readonly Mock<IDirectoryReader> _directoryReader;
        private readonly IPluginInitialization _pluginInit;
        private readonly IPluginSet _pluginSet;

        public List<PluginInfo> DataRecords { get; set; } = new List<PluginInfo>();
        public List<string> Folders { get; set; } = new List<string>();

        public PluginInitialization_Should()
        {
            _dataStore = new Mock<IDataStore>();
            _directoryReader = new Mock<IDirectoryReader>();
            var mockSender = new Mock<IMessageSender>();

            ServiceProvider provider = SetUpServices(x =>
            {
                x.AddSingleton(mockSender.Object);
                x.AddSingleton(_dataStore.Object);
                x.AddSingleton(_directoryReader.Object);
                x.AddDomain(FakeSettingsBuilder.New().WithTestData().Build());
            });

            SetReturnValues();

            _pluginInit = provider.GetRequiredService<IPluginInitialization>();
            _pluginSet = provider.GetRequiredService<IPluginSet>();
        }

        [Fact]
        public void SetNoPluginData_GivenEmptyFolderAndDatabase()
        {
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
            Folders.AddRange(pluginNames);

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
        public void AddsPluginInfoAsNew_GivenEmptyDatabaseAndNewFolder()
        {
            var folder = "The New Folder";
            Folders.Add(folder);

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().ContainSingle();
            _pluginSet.Plugins.Single().Location.Should().Be(folder);
            _pluginSet.Plugins.Single().Status.Should().Be(PluginStatuses.New);
        }

        [Fact]
        public void AddsPluginInfoAsMissing_GivenDatabaseDataAndEmptyFolder()
        {
            var pluginInfo = new PluginInfo();
            DataRecords.Add(pluginInfo);

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
            DataRecords.Add(pluginInfo);
            Folders.Add(pluginName);

            _pluginInit.Initialize();

            _dataStore.Verify();
            _directoryReader.Verify();
            _pluginSet.Plugins.Should().ContainSingle();
            _pluginSet.Plugins.Should().Contain(pluginInfo);
            _pluginSet.Plugins.Single().Status.Should().Be(status);
        }

        private void SetReturnValues()
        {
            _dataStore.Setup(x => x.GetEntities<PluginInfo>())
                .Returns(() => DataRecords)
                .Verifiable();
            _directoryReader.Setup(x => x.ReadPluginsFolder())
                .Returns(() => Folders)
                .Verifiable();
        }
    }
}
