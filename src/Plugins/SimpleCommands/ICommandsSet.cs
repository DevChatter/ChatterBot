using System.Collections.Generic;
using System.ComponentModel;

namespace ChatterBot.Plugins.SimpleCommands
{
    public interface ICommandsSet
    {
        BindingList<CustomCommand> CustomCommands { get; }
        IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage);
    }
}