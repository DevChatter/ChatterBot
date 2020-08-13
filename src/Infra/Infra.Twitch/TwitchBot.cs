using ChatterBot.Auth;
using ChatterBot.Infra.Twitch.Extensions;
using ChatterBot.Interfaces;
using ChatterBot.State;
using System;
using TwitchLib.Client.Events;

namespace ChatterBot.Infra.Twitch
{
    internal class TwitchBot : TwitchConnection
    {
        private readonly IMessageHandlerSet _messageHandlerSet;

        public TwitchBot(IDataProtection dataProtection,
            IMessageHandlerSet messageHandlerSet)
            : base(dataProtection)
        {
            _messageHandlerSet = messageHandlerSet;
        }

        protected override void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            string message = "Hey everyone! I am a bot connected via TwitchLib!";
            Console.WriteLine(message);
            Client.SendMessage(e.Channel, message);
        }

        protected override void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            ChatMessage chatMessage = e.ChatMessage.ToDomain();
            foreach (IMessageHandler messageHandler in _messageHandlerSet.Handlers)
            {
                messageHandler.Handle(chatMessage,
                    response => Client.SendMessage(e.ChatMessage.Channel, response));
            }
        }
    }
}
