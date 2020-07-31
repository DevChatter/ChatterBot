using ChatterBot.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ChatterBot.ViewModels
{
    public class TerminalViewModel : MenuItemViewModel
    {
        public ObservableCollection<ChatMessage> Messages { get; } = new ObservableCollection<ChatMessage>();

        public TerminalViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            for (int i = 0; i < 100; i++)
            {
                AddMessage(new ChatMessage(DateTime.UtcNow.AddMinutes(i), "Brendoneus",
                    new SolidColorBrush(Color.FromRgb(255, 205, 0)),
                    $"Hello, everyone! {i}"));
            }
        }

        public void AddMessage(ChatMessage message)
        {
            Messages.Add(message);
        }
    }
}