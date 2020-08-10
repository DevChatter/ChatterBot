using ChatterBot.Core;
using ChatterBot.Core.Interfaces;
using MahApps.Metro.IconPacks;
using System.ComponentModel;

namespace ChatterBot.Plugins.SimpleCommands
{
    public class CommandsViewModel : BaseViewModel, IMenuItemViewModel
    {
        private readonly ICommandsSet _commandsSet;

        public BindingList<CustomCommand> CustomCommands => _commandsSet.CustomCommands;

        public CommandsViewModel(ICommandsSet commandsSet)
        {
            _commandsSet = commandsSet;
            Icon = new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.ExclamationSolid };
            Label = "Commands";
            ToolTip = "Custom Commands";
            IsOption = false;
            Content = new CommandsView();
        }

        public object Icon { get; }
        public object Label { get; }
        public object ToolTip { get; }
        public bool IsVisible { get; set; }
        public bool IsOption { get; }
        public object Content { get; }
    }
}