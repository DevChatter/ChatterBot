using ChatterBot.Core.Auth;
using System;
using TwitchLib.Client.Events;

namespace ChatterBot.Infra.Twitch
{
    public class TwitchBot : TwitchConnection
    {
        public TwitchBot(DataProtection dataProtection) : base(dataProtection)
        {
        }

        protected override void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var message = "Hey everyone! I am a bot connected via TwitchLib!";
            Console.WriteLine(message);
            Client.SendMessage(e.Channel, message);
        }


        protected override void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.ToLower().StartsWith("ping"))
            {
                Client.SendMessage(e.ChatMessage.Channel, "PONG");
            }
        }

    }
}
