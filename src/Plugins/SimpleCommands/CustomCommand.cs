using ChatterBot.Core;
using ChatterBot.Plugins.SimpleCommands.Validation;
using System;
using System.ComponentModel;
using System.Linq;

namespace ChatterBot.Plugins.SimpleCommands
{
    public class CustomCommand : BaseBindable, IDataErrorInfo
    {
        public int Id { get; set; }

        private string _commandWord = "!";
        private Access _access = Access.Everyone;
        private string _response = "";
        private int _cooldownTime;
        private int _userCooldownTime;
        private bool _enabled = true;
        private readonly CustomCommandValidator _validator;

        public CustomCommand()
        {
            _validator = new CustomCommandValidator();
        }

        public string CommandWord
        {
            get => _commandWord;
            set => SetProperty(ref _commandWord, value);
        }

        public Access Access
        {
            get => _access;
            set => SetProperty(ref _access, value);
        }

        public string Response
        {
            get => _response;
            set => SetProperty(ref _response, value);
        }

        public int CooldownTime
        {
            get => _cooldownTime;
            set => SetProperty(ref _cooldownTime, value);
        }

        public int UserCooldownTime
        {
            get => _userCooldownTime;
            set => SetProperty(ref _userCooldownTime, value);
        }

        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }

        public void Run(Action<string> respond)
        {
            respond(Response);
        }

        public string Error
            => string.Join(Environment.NewLine,
                _validator?.Validate(this)?.Errors?.Select(x => x.ErrorMessage).ToArray()
                ?? new string[0]);

        public string this[string columnName]
            => _validator
                ?.Validate(this)
                ?.Errors
                ?.FirstOrDefault(x => x.PropertyName == columnName)
                ?.ErrorMessage ?? "";
    }
}