using ChatterBot.Interfaces;
using ChatterBot.State;
using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    public class MessageHandlerSet : IMessageHandlerSet
    {
        public ICollection<IMessageHandler> Handlers { get; } = new HashSet<IMessageHandler>();

        public void Initialize(IEnumerable<IMessageHandler> messageHandlers)
        {
            foreach (var handler in messageHandlers)
            {
                Handlers.Add(handler);
            }
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
