using ChatterBot.Twitch;
using System;

namespace ChatterBot.Interfaces
{
    public interface IMessageHandler
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        void HandleMessage(ChatMessage chatMessage);
    }
}