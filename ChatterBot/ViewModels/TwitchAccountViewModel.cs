using ChatterBot.Core.Auth;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ChatterBot.ViewModels
{
    public abstract class TwitchAccountViewModel : MenuItemViewModel
    {
        private string _username;
        private string _oAuth;
        private bool _isConnected;
        private bool _isDisconnected = true;
        private bool _isManualEntry = false;
        private bool _isGeneratedEntry = true;
        private readonly TwitchAuthentication _twitchAuthentication;

        protected TwitchAccountViewModel(TwitchAuthentication twitchAuthentication)
        {
            _twitchAuthentication = twitchAuthentication;
            ConnectCommand = new ActionCommand(Connect);
            DisconnectCommand = new ActionCommand(Disconnect);
            GenerateTokenCommand = new ActionCommand(GenerateToken);
            ManualEntryCommand = new ActionCommand(SwitchToManualEntry);
        }

        private void SwitchToManualEntry()
        {
            IsManualEntry = true;
            IsGeneratedEntry = false;
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

        protected abstract AuthenticationType AuthType { get; }

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
        public ICommand ManualEntryCommand { get; set; }
    }
}