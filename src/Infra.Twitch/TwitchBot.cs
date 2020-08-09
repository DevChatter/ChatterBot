using ChatterBot.Core;
using ChatterBot.Core.Auth;
using ChatterBot.Core.SimpleCommands;
using ChatterBot.Infra.Twitch.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Events;

namespace ChatterBot.Infra.Twitch
{
    internal class TwitchBot : TwitchConnection
    {
        private readonly CommandsSet _commandsSet;

        public TwitchBot(IDataProtection dataProtection, CommandsSet commandsSet)
            : base(dataProtection)
        {
            _commandsSet = commandsSet;
        }

        protected override void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var message = "Hey everyone! I am a bot connected via TwitchLib!";
            Console.WriteLine(message);
            Client.SendMessage(e.Channel, message);
        }

        protected override void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            ChatMessage chatMessage = e.ChatMessage.ToDomain();
            IEnumerable<CustomCommand> toRun = _commandsSet.GetCommandsToRun(chatMessage);

            foreach (CustomCommand command in toRun)
            {
                command.Run(message => Client.SendMessage(e.ChatMessage.Channel, message));
            }
        }
    }
}
