using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChatterBot.Core.State
{
    public class CommandsSet
    {
        public ObservableCollection<CustomCommand> CustomCommands { get; }
            = new ObservableCollection<CustomCommand>();

        public IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage)
        {
            return CustomCommands
                .Where(command => chatMessage.Text.StartsWith(command.CommandWord,
                    StringComparison.InvariantCultureIgnoreCase));
        }
    }
}