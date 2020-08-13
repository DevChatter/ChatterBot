using ChatterBot.Interfaces;
using ChatterBot.State;
using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    public class MessageHandlerSet : IMessageHandlerSet
    {
        public List<IMessageHandler> Handlers { get; } = new List<IMessageHandler>();
        public void Initialize(IEnumerable<IMessageHandler> messageHandlers)
        {
            Handlers.AddRange(messageHandlers);
        }

        public void Register(IMessageHandler messageHandler)
        {
            Handlers.Add(messageHandler);
        }

        public void UnRegister(IMessageHandler messageHandler)
        {
            Handlers.Remove(messageHandler);
        }
    }
}
