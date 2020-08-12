using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace ChatterBot.Plugins.SimpleCommands.Validation
{
    [SuppressMessage("Build", "CA1812", Justification = "Compiler doesn't understand dependency injection")]
    [SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "Fluent Validators are never used as collections directly")]
    internal class CustomCommandValidator : AbstractValidator<CustomCommand>, ICustomCommandValidator
    {
        private const int TwitchMessageMaximum = 500;

        public CustomCommandValidator()
        {
            RuleFor(x => x.CommandWord)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(TwitchMessageMaximum).WithMessage("{PropertyName} length cannot exceed {MaxLength}. Entered {TotalLength}.");

            RuleFor(x => x.Response)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(TwitchMessageMaximum).WithMessage("{PropertyName} length cannot exceed {MaxLength}. Entered {TotalLength}.");

            RuleFor(x => x.CooldownTime)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cannot be negative.")
                .LessThanOrEqualTo(1440).WithMessage("{PropertyName} cannot be more than a day.");

            RuleFor(x => x.UserCooldownTime)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} cannot be negative.")
                .LessThanOrEqualTo(1440).WithMessage("{PropertyName} cannot be more than a day.");
        }
    }
}
