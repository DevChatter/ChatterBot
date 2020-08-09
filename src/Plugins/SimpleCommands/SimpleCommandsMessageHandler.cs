using ChatterBot.Core;
using ChatterBot.Core.Interfaces;
using ChatterBot.Core.SimpleCommands;
using System;
using System.Collections.Generic;

namespace ChatterBot.Plugins.SimpleCommands
{
    public class SimpleCommandsMessageHandler : IMessageHandler
    {
        private readonly CommandsSet _commandsSet;

        public SimpleCommandsMessageHandler(CommandsSet commandsSet)
        {
            _commandsSet = commandsSet;
        }

        public void Handle(ChatMessage chatMessage, Action<string> respond)
        {
            IEnumerable<CustomCommand> toRun = _commandsSet.GetCommandsToRun(chatMessage);

            foreach (CustomCommand command in toRun)
            {
                command.Run(respond);
            }
        }
    }
}