using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    public class CommandsSet : ICommandsSet
    {
        public CommandsSet(List<CustomCommand> commands)
        {
            CustomCommands = new BindingList<CustomCommand>(commands);
        }

        public BindingList<CustomCommand> CustomCommands { get; }

        public IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage) =>
            CustomCommands
                .Where(command =>
                    command.Enabled
                    && TextMatchesCommand(chatMessage, command));

        private static bool TextMatchesCommand(ChatMessage chatMessage, CustomCommand command)
            => chatMessage.Text.StartsWith(command.CommandWord, StringComparison.InvariantCultureIgnoreCase);
    }
}