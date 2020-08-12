using System;

namespace ChatterBot
{
    public class ChatMessage
    {
        public DateTime TimeStamp { get; set; }
        public string DisplayName { get; set; }
        public string UserColor { get; set; }
        public string Text { get; set; }

        public ChatMessage(DateTime timeStamp, string displayName, string userColor, string text)
        {
            TimeStamp = timeStamp;
            DisplayName = displayName;
            Text = text;
            UserColor = userColor;
        }
    }
}