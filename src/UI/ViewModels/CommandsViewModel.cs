using ChatterBot.Core;
using ChatterBot.Core.State;
using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;

namespace ChatterBot.ViewModels
{
    public class CommandsViewModel : MenuItemViewModel
    {
        private readonly CommandsSet _commandsSet;

        public ObservableCollection<CustomCommand> CustomCommands => _commandsSet.CustomCommands;

        public CommandsViewModel(CommandsSet commandsSet)
        {
            _commandsSet = commandsSet;
            Icon = new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.ExclamationSolid };
            Label = "Commands";
            ToolTip = "Custom Commands";

            CustomCommands.Add(new CustomCommand
            {
                Access = Access.Everyone,
                CommandWord = "!ping",
                Response = "Pong!"
            });
            CustomCommands.Add(new CustomCommand
            {
                Access = Access.VIPs,
                CommandWord = "!so",
                Response = "Huge shout out to $arg1! Go check them out! https://www.twitch.tv/$name1"
            });
        }
    }
}