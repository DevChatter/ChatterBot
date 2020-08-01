namespace ChatterBot.ViewModels
{
    public class TwitchBotViewModel : TwitchAccountViewModel
    {
        private string _channel;

        public TwitchBotViewModel(BaseViewModel windowViewModel) : base(windowViewModel)
        {
        }

        public string Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }

    }
}