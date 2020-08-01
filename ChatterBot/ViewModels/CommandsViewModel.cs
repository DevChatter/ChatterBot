using ChatterBot.Core;
using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class CommandsViewModel : MenuItemViewModel
    {
        public ObservableCollection<CustomCommand> CustomCommands { get; } = new ObservableCollection<CustomCommand>();

        public CommandsViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
        }
    }
}