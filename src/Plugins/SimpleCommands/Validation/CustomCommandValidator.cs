using ChatterBot.Domain.Validation;
using FluentValidation;

namespace ChatterBot.Plugins.SimpleCommands.Validation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812", Justification = "Compiler dosen't understand dependency injection")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "Fluent Validators are never used as collections directly")]
    internal class CustomCommandValidator : AbstractValidator<CustomCommand>, ICustomCommandValidator
    {
        public CustomCommandValidator()
        {
            // TOOD: Add additional validation rules.
            this.RuleFor(x => x.CommandWord).NotEmpty().WithMessage("{PropertyName} must not be empty.");
            this.RuleFor(x => x.CommandWord).Must(x => x.StartsWith("!")).WithMessage("{PropertyName} must start with a '!' character.");
        }
    }
}
