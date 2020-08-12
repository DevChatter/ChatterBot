using FluentValidation;

namespace ChatterBot.Plugins.SimpleCommands.Validation
{
    public interface ICustomCommandValidator : IValidator<CustomCommand>
    {
    }
}
