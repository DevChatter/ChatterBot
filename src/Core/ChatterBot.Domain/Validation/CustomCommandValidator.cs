using ChatterBot.Core.SimpleCommands;
using FluentValidation;

namespace ChatterBot.Domain.Validation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812", Justification = "Compiler dosen't understand dependency injection")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "Fluent Validators are never used as collections directly")]
    internal class CustomCommandValidator : AbstractValidator<CustomCommand>, ICustomCommandValidator
    {
        public CustomCommandValidator()
        {
            //this.RuleFor(x => x.DecimalFormat)
            //    .NotEmpty()
            //    .MaximumLength(Currency.DecimalFormatMaxLength);

            //this.RuleFor(x => x.Symbol)
            //    .NotEmpty()
            //    .MaximumLength(Currency.SymbolMaxLength);
        }
    }
}
