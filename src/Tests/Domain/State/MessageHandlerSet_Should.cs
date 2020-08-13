using ChatterBot.Domain.State;
using ChatterBot.Interfaces;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChatterBot.Tests.Domain.State
{
    public class MessageHandlerSet_Should
    {
        [Fact]
        public void NotChangeCollection_AfterInitialize()
        {
            var handlerSet = new MessageHandlerSet();
            var original = handlerSet.Handlers;

            handlerSet.Initialize(new List<IMessageHandler>());

            handlerSet.Handlers.Should().BeSameAs(original);
        }

        [Fact]
        public void AddAllHandlers_GivenInInitialize()
        {
            var handlerSet = new MessageHandlerSet();

            var handler = Mock.Of<IMessageHandler>();

            handlerSet.Initialize(new[] { handler });

            handlerSet.Handlers.Single().Should().BeSameAs(handler);
        }

        [Fact]
        public void AddHandler_OnRegister()
        {
            var handlerSet = new MessageHandlerSet();
            var handler1 = Mock.Of<IMessageHandler>();
            var handler2 = Mock.Of<IMessageHandler>();
            handlerSet.Initialize(new IMessageHandler[] { });

            handlerSet.Register(handler1);
            handlerSet.Register(handler2);

            handlerSet.Handlers.Should().ContainSingle(x => x == handler1);
            handlerSet.Handlers.Should().ContainSingle(x => x == handler2);
        }

        [Fact]
        public void RemoveHandler_OnUnRegister()
        {
            var handlerSet = new MessageHandlerSet();
            var handler1 = Mock.Of<IMessageHandler>();
            var handler2 = Mock.Of<IMessageHandler>();
            handlerSet.Initialize(new[] { handler1, handler2 });

            handlerSet.UnRegister(handler1);
            handlerSet.Handlers.Should().NotContain(x => x == handler1);

            handlerSet.UnRegister(handler2);
            handlerSet.Handlers.Should().NotContain(x => x == handler2);

            handlerSet.Handlers.Should().BeEmpty();
        }
    }
}
