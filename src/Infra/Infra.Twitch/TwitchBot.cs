using ChatterBot.Auth;
using ChatterBot.Infra.Twitch.Extensions;
using ChatterBot.Interfaces;
using System;
using TwitchLib.Client.Events;

namespace ChatterBot.Infra.Twitch
{
    internal class TwitchBot : TwitchConnection
    {
        private readonly IMessageHandler _messageHandler;

        public TwitchBot(IDataProtection dataProtection,
            IMessageHandler messageHandler)
            : base(dataProtection)
        {
            _messageHandler = messageHandler;
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
            _messageHandler.HandleMessage(chatMessage);
        }
    }
}
