using System;

namespace ChatterBot.Twitch
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public ChatMessage ChatMessage { get; }

        public MessageReceivedEventArgs(ChatMessage chatMessage)
        {
            ChatMessage = chatMessage;
        }
    }
}