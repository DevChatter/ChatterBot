using System.Collections.Generic;
using System.ComponentModel;

namespace ChatterBot.Core.SimpleCommands
{
    public interface ICommandsSet
    {
        BindingList<CustomCommand> CustomCommands { get; }

        IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage);
        void Initialize(List<CustomCommand> commands);
    }
}