using System;

namespace ChatterBot.Interfaces
{
    public interface IMessageHandler
    {
        void Handle(ChatMessage chatMessage, Action<string> respond);
    }
}