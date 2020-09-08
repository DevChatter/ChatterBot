using System;

namespace ChatterBot
{
    public class ChatMessage
    {
        public DateTime TimeStamp { get; set; }
        public string DisplayName { get; set; }
        public string UserColor { get; set; }
        public string Text { get; set; }
        public string Channel { get; set; }

        public ChatMessage(DateTime timeStamp, string displayName, string userColor, string text, string channel)
        {
            TimeStamp = timeStamp;
            DisplayName = displayName;
            Text = text;
            Channel = channel;
            UserColor = userColor;
        }
    }
}