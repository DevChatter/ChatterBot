using ChatterBot.Interfaces;
using System;
using System.Collections.Generic;

namespace ChatterBot.Plugins.SimpleCommands
{
    internal class SimpleCommandsMessageHandler : IMessageHandler
    {
        private readonly ICommandsSet _commandsSet;

        public SimpleCommandsMessageHandler(ICommandsSet commandsSet)
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