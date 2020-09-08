using ChatterBot.Plugins.SimpleCommands;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatterBot.Tests.CustomCommandTests
{
    public class GetCommandsToRun_Should
    {
        private readonly ICommandsSet _commandsSet;

        public GetCommandsToRun_Should()
        {
            var customCommand = new CustomCommand
            {
                CommandWord = "!ping",
                Response = "PONG",
                Enabled = true,
                Access = Access.Everyone,
            };
            _commandsSet = new CommandsSet(new List<CustomCommand> { customCommand });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ReturnEmpty_GivenNonMatchingMessage()
        {
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", "Hello!", "DevChatter");

            IEnumerable<CustomCommand> result = _commandsSet.GetCommandsToRun(chatMessage);

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
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", text, "DevChatter");

            IEnumerable<CustomCommand> result = _commandsSet.GetCommandsToRun(chatMessage);

            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Unit")]
        public void ReturnMatchingCommand_WhenEnabled(bool enabled)
        {
            string text = "!Ted";
            _commandsSet.CustomCommands.Add(new CustomCommand
            {
                Response = "C# <3 Java",
                Access = Access.Everyone,
                CommandWord = text,
                Enabled = enabled,
            });
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", text, "DevChatter");

            IEnumerable<CustomCommand> result = _commandsSet.GetCommandsToRun(chatMessage);

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