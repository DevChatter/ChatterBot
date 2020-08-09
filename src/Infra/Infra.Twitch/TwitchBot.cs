using ChatterBot.Core;
using ChatterBot.Core.Auth;
using ChatterBot.Core.Interfaces;
using ChatterBot.Infra.Twitch.Extensions;
using System;
using System.Collections.Generic;
using TwitchLib.Client.Events;

namespace ChatterBot.Infra.Twitch
{
    internal class TwitchBot : TwitchConnection
    {
        private readonly IEnumerable<IMessageHandler> _messageHandlers;

        public TwitchBot(IDataProtection dataProtection, IEnumerable<IMessageHandler> messageHandlers)
            : base(dataProtection)
        {
            _messageHandlers = messageHandlers;
        }

        protected override void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            var message = "Hey everyone! I am a bot connected via TwitchLib!";
            Console.WriteLine(message);
            Client.SendMessage(e.Channel, message);
        }

        protected override void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            ChatMessage chatMessage = e.ChatMessage.ToDomain();
            foreach (IMessageHandler messageHandler in _messageHandlers)
            {
                messageHandler.Handle(chatMessage,
                    response => Client.SendMessage(e.ChatMessage.Channel, response));
            }
        }
    }
}
