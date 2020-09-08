using ChatterBot.Interfaces;
using System;

namespace ChatterBot.Twitch
{
    public class MessageHandler : IMessageHandler
    {
        public MessageHandler()
        {
            MessageReceived += (sender, args) => { };
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void HandleMessage(ChatMessage chatMessage)
        {
            var eventArgs = new MessageReceivedEventArgs(chatMessage);
            OnMessageReceived(eventArgs);
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs eventArgs)
        {
            MessageReceived?.Invoke(this, eventArgs);
        }
    }
}