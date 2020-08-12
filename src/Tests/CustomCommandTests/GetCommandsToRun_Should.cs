using ChatterBot.Plugins.SimpleCommands;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatterBot.Tests.CustomCommandTests
{
    public class GetCommandsToRun_Should
    {
        private readonly ICommandsSet _commandsSet;
        private readonly CustomCommand _customCommand;

        public GetCommandsToRun_Should()
        {
            var services = new ServiceCollection();
            services.AddSimpleCommandsPlugin();

            _commandsSet = services.BuildServiceProvider().GetService<ICommandsSet>();
            _customCommand = new CustomCommand
            {
                CommandWord = "!ping",
                Response = "PONG",
                Enabled = true,
                Access = Access.Everyone,
            };
            _commandsSet.Initialize(new List<CustomCommand> { _customCommand });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ReturnEmpty_GivenNonMatchingMessage()
        {
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", "Hello!");

            var result = _commandsSet.GetCommandsToRun(chatMessage);

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData("!ping")]
        [InlineData("!pinG")]
        [InlineData("!pInG")]
        [InlineData("!pING")]
        [InlineData("!PING")]
        [Trait("Category", "Unit")]
        public void ReturnCommand_GivenMatchingCommandWord_RegardlessOfCasing(string text)
        {
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", text);

            var result = _commandsSet.GetCommandsToRun(chatMessage);

            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Unit")]
        public void ReturnMatchingCommand_WhenEnabled(bool enabled)
        {
            var text = "!Ted";
            _commandsSet.CustomCommands.Add(new CustomCommand
            {
                Response = "C# <3 Java",
                Access = Access.Everyone,
                CommandWord = text,
                Enabled = enabled,
            });
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", text);

            var result = _commandsSet.GetCommandsToRun(chatMessage);

            if (enabled)
            {
                result.Should().ContainSingle();
            }
            else
            {
                result.Should().BeEmpty();
            }
        }
    }
}