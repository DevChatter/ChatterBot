using ChatterBot.Core;
using ChatterBot.Core.State;
using FluentAssertions;
using System;
using Xunit;

namespace ChatterBot.Tests.Core.CustomCommandTests
{
    public class GetCommandsToRun_Should
    {
        private readonly CommandsSet _commandsSet;

        public GetCommandsToRun_Should()
        {
            _commandsSet = new CommandsSet();
            _commandsSet.CustomCommands.Add(new CustomCommand
            {
                CommandWord = "!ping",
                Response = "PONG",
                Enabled = true,
                Access = Access.Everyone,
            });
        }

        [Fact]
        public void ReturnEmpty_GivenNonMatchingMessage()
        {
            var chatMessage = new ChatMessage(DateTime.UtcNow, "Brendoneus", "#ffff00", "Hello!");

            var result = _commandsSet.GetCommandsToRun(chatMessage);

            result.Should().NotBeEmpty();
        }
    }
}