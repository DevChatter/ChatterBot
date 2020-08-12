using ChatterBot.Auth;
using ChatterBot.Infra.Twitch.Extensions;
using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;

namespace ChatterBot.Infra.Twitch
{
    internal class TwitchConnection : ITwitchConnection
    {
        private readonly IDataProtection _dataProtection;
        protected readonly TwitchClient Client;

        public TwitchConnection(IDataProtection dataProtection)
        {
            _dataProtection = dataProtection;
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            Client = new TwitchClient(customClient);

            Client.OnLog += Client_OnLog;
            Client.OnJoinedChannel += Client_OnJoinedChannel;
            Client.OnMessageReceived += Client_OnMessageReceived;
            Client.OnWhisperReceived += Client_OnWhisperReceived;
            Client.OnConnected += Client_OnConnected;
            Client.OnError += Client_OnError;
            Client.OnConnectionError += Client_OnConnectionError;
            Client.OnNoPermissionError += Client_OnNoPermissionError;
        }

        private void Client_OnNoPermissionError(object? sender, EventArgs e)
        {
        }

        private void Client_OnConnectionError(object? sender, OnConnectionErrorArgs e)
        {
        }

        private void Client_OnError(object? sender, OnErrorEventArgs e)
        {
        }

        public void Connect(TwitchCredentials twitchCredentials)
        {
            ConnectionCredentials credentials = twitchCredentials.ToTwitchLib(_dataProtection);
            Client.Initialize(credentials, twitchCredentials.Channel.ToLowerInvariant());

            Client.Connect();
        }

        public void Disconnect()
        {
            Client.Disconnect();
        }

        protected virtual void Client_OnLog(object? sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }

        protected virtual void Client_OnConnected(object? sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        protected virtual void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
        }

        protected virtual void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
        }

        protected virtual void Client_OnWhisperReceived(object? sender, OnWhisperReceivedArgs e)
        {
        }
    }
}