using ChatterBot.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    public class CommandsSet : ICommandsSet
    {
        public BindingList<CustomCommand> CustomCommands { get; private set; }

        public IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage) =>
            CustomCommands
                .Where(command =>
                    command.Enabled
                    && TextMatchesCommand(chatMessage, command));

        private static bool TextMatchesCommand(ChatMessage chatMessage, CustomCommand command)
            => chatMessage.Text.StartsWith(command.CommandWord, StringComparison.InvariantCultureIgnoreCase);

        public void Initialize(List<CustomCommand> commands)
        {
            CustomCommands = new BindingList<CustomCommand>(commands);
        }
    }
}