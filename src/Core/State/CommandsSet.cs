using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChatterBot.Core.State
{
    public class CommandsSet
    {
        public ObservableCollection<CustomCommand> CustomCommands { get; }
            = new ObservableCollection<CustomCommand>();

        public IEnumerable<CustomCommand> GetCommandsToRun(ChatMessage chatMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}