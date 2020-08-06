using ChatterBot.Core.Auth;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ChatterBot.ViewModels
{
    public abstract class TwitchAccountViewModel : MenuItemViewModel
    {
        private bool _isConnected;
        private bool _isDisconnected = true;
        private bool _isManualEntry = false;
        private bool _isGeneratedEntry = true;
        private readonly TwitchAuthentication _twitchAuthentication;
        private readonly ITwitchBot _twitchBot;

        protected TwitchAccountViewModel(TwitchAuthentication twitchAuthentication,
            ITwitchBot twitchBot,
            AuthenticationType authType)
        {
            AuthType = authType;
            _twitchAuthentication = twitchAuthentication;
            _twitchBot = twitchBot;
            ConnectCommand = new ActionCommand(Connect);
            DisconnectCommand = new ActionCommand(Disconnect);
            GenerateTokenCommand = new ActionCommand(GenerateToken);
            ManualEntryCommand = new ActionCommand(SwitchToManualEntry);

            if (!_twitchAuthentication.Credentials.ContainsKey(AuthType))
            {
                _twitchAuthentication.Credentials[AuthType] = new TwitchCredentials();
            }
        }

        private void SwitchToManualEntry()
        {
            IsManualEntry = true;
            IsGeneratedEntry = false;
        }

        protected virtual void Connect()
        {
            _twitchBot.Connect(Credentials);
            IsConnected = true;
            IsDisconnected = false;
        }

        protected virtual void Disconnect()
        {
            _twitchBot.Disconnect();
            IsConnected = false;
            IsDisconnected = true;
        }

        protected AuthenticationType AuthType { get; }

        public TwitchCredentials Credentials => _twitchAuthentication.Credentials[AuthType];

        protected virtual void GenerateToken()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = _twitchAuthentication.GetUrl(AuthType),
                    UseShellExecute = true
                };
                Process.Start(psi);


                IsManualEntry = false;
                IsGeneratedEntry = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsGeneratedEntry
        {
            get => _isGeneratedEntry;
            set => SetProperty(ref _isGeneratedEntry, value);
        }

        public bool IsManualEntry
        {
            get => _isManualEntry;
            set => SetProperty(ref _isManualEntry, value);
        }

        public virtual string Username
        {
            get => Credentials.Username;
            set => SetProperty(() => Credentials.Username, x => Credentials.Username = x, value);
        }

        public string OAuth
        {
            get => Credentials.AuthToken;
            set => SetProperty(() => Credentials.AuthToken, x => Credentials.AuthToken = x, value);
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
        public ICommand ManualEntryCommand { get; set; }
    }
}