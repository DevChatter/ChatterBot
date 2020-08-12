using ChatterBot.Views;
using MahApps.Metro.IconPacks;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace ChatterBot.ViewModels
{
    public class TerminalViewModel : MenuItemViewModel
    {
        public ObservableCollection<ChatMessage> Messages { get; } = new ObservableCollection<ChatMessage>();

        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _selectedUser = "DevChatter";
        public string SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public Color UserColor { get; set; } = Color.FromRgb(255, 0, 0);

        public TerminalViewModel()
            : base(new PackIconMaterialDesign { Kind = PackIconMaterialDesignKind.Chat },
                "Chat", "Console and Chat", new TerminalView())
        {
        }

        public void SendMessage()
        {
            Messages.Add(Message);
            Text = string.Empty;
        }

        private ICommand? _sendMessageCommand;
        public ICommand SendMessageCommand => _sendMessageCommand ??= new ActionCommand(SendMessage);

        public ChatMessage Message => new ChatMessage(DateTime.UtcNow,
            SelectedUser,
            UserColor.ToString(),
            Text);
    }
}