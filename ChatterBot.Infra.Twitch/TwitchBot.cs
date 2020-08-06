using ChatterBot.Core.Auth;
using ChatterBot.Infra.Twitch.Extensions;
using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace ChatterBot.Infra.Twitch
{
    public class TwitchBot : ITwitchBot
    {
        private readonly TwitchClient _client;

        public TwitchBot()
        {
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            _client = new TwitchClient(customClient);
        }

        public void Connect(TwitchCredentials twitchCredentials)
        {
            // TODO: Decrypt here.
            ConnectionCredentials credentials = twitchCredentials.ToTwitchLib();
            _client.Initialize(credentials, twitchCredentials.Channel);

            _client.OnLog += Client_OnLog;
            _client.OnJoinedChannel += Client_OnJoinedChannel;
            _client.OnMessageReceived += Client_OnMessageReceived;
            _client.OnWhisperReceived += Client_OnWhisperReceived;
            _client.OnConnected += Client_OnConnected;

            _client.Connect();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var message = "Hey everyone! I am a bot connected via TwitchLib!";
            Console.WriteLine(message);
            _client.SendMessage(e.Channel, message);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.ToLower().StartsWith("ping"))
            {
                _client.SendMessage(e.ChatMessage.Channel, "PONG");
            }
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
        }
    }
}
