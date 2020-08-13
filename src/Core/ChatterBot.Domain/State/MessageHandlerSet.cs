using ChatterBot.Interfaces;
using ChatterBot.State;
using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    public class MessageHandlerSet : BaseSet<IMessageHandler>, IMessageHandlerSet
    {
        public ICollection<IMessageHandler> Handlers => Items;
    }
}
