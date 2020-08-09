using ChatterBot.Core;
using ChatterBot.Core.SimpleCommands;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ChatterBot.Tests.Core.CustomCommandTests
{
    public class GetCommandsToRun_Should
    {
        private readonly CommandsSet _commandsSet;
        private readonly CustomCommand _customCommand;

        public GetCommandsToRun_Should()
        {
            _commandsSet = new CommandsSet();
            _customCommand = new CustomCommand
            {
                CommandWord = "!ping",
                Response = "PONG",
                Enabled = true,
                Access = Access.Everyone,
            };
            _commandsSet.CustomCommands.Add(_customCommand);
        }

        [Fact]
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
        public void ReturnCommand_GivenMatchingCommandWord_RegardlessOfCasing(string text)
        {
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", text);

            var result = _commandsSet.GetCommandsToRun(chatMessage);

            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
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