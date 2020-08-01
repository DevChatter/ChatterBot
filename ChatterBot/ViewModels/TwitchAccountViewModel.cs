using Microsoft.Xaml.Behaviors.Core;
using System.Windows.Input;

namespace ChatterBot.ViewModels
{
    public abstract class TwitchAccountViewModel : MenuItemViewModel
    {
        private string _username;
        private string _oAuth;
        private bool _isConnected;
        private bool _isDisconnected = true;

        protected TwitchAccountViewModel(BaseViewModel windowViewModel) : base(windowViewModel)
        {
            ConnectCommand = new ActionCommand(Connect);
            DisconnectCommand = new ActionCommand(Disconnect);
            GenerateTokenCommand = new ActionCommand(GenerateToken);
        }

        protected virtual void Connect()
        {
            IsConnected = true;
            IsDisconnected = false;
        }

        protected virtual void Disconnect()
        {
            IsConnected = false;
            IsDisconnected = true;
        }

        protected virtual void GenerateToken()
        {
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string OAuth
        {
            get => _oAuth;
            set => SetProperty(ref _oAuth, value);
        }

        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }

        public bool IsDisconnected
        {
            get => _isDisconnected;
            set => SetProperty(ref _isDisconnected, value);
        }

        public ICommand ConnectCommand { get; set; }
        public ICommand DisconnectCommand { get; set; }
        public ICommand GenerateTokenCommand { get; set; }
    }
}