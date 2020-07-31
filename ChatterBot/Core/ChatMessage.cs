using System;
using System.Windows.Media;

namespace ChatterBot.Core
{
    public class ChatMessage
    {
        public DateTime TimeStamp { get; set; }
        public string DisplayName { get; set; }
        public Brush UserColor { get; set; }
        public string Text { get; set; }

        public ChatMessage(DateTime timeStamp, string displayName, Brush userColor, string text)
        {
            TimeStamp = timeStamp;
            DisplayName = displayName;
            Text = text;
            UserColor = userColor;
        }
    }
}