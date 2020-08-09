using System;

namespace ChatterBot.Core.Interfaces
{
    public interface IMessageHandler
    {
        void Handle(ChatMessage chatMessage, Action<string> respond);
    }
}