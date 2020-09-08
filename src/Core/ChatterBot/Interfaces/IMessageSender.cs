namespace ChatterBot.Interfaces
{
    public interface IMessageSender
    {
        void SendMessage(string channel, string message);
        void SendWhisper(string username, string message);
    }
}