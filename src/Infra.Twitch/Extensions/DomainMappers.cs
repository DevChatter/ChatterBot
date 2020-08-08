using ChatterBot.Core;
using System;

namespace ChatterBot.Infra.Twitch.Extensions
{
    public static class DomainMappers
    {
        public static ChatMessage ToDomain(this TwitchLib.Client.Models.ChatMessage message) =>
            new ChatMessage(DateTime.UtcNow,
                message.DisplayName, message.ColorHex, message.Message);
    }
}