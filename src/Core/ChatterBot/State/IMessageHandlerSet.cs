using ChatterBot.Interfaces;
using System.Collections.Generic;

namespace ChatterBot.State
{
    public interface IMessageHandlerSet
    {
        ICollection<IMessageHandler> Handlers { get; }
        void Initialize(IEnumerable<IMessageHandler> messageHandlers);
        void Register(IMessageHandler messageHandler);
        void UnRegister(IMessageHandler messageHandler);
    }
}