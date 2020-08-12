using ChatterBot.Core;
using ChatterBot.Plugins.SimpleCommands;
using ChatterBot.Plugins.SimpleCommands.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace ChatterBot.Tests.Domain.Validation
{
    public class CustomCommandValidator_Should
    {
        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_IsValid_GivenValidCustomCommand()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSimpleCommandsPlugin();

            var command = new CustomCommand
            {
                CommandWord = "!ping",
                Response = "PONG!",
                Access = Access.Everyone,
                CooldownTime = 0,
                UserCooldownTime = 0,
            };

            // Act
            var result = await services.BuildServiceProvider().GetRequiredService<ICustomCommandValidator>().ValidateAsync(command).ConfigureAwait(false);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_ValidationError_GivenCustomCommand_WithZeroLengthCommandWord()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSimpleCommandsPlugin();

            var command = new CustomCommand() { CommandWord = string.Empty };

            // Act
            var result = await services.BuildServiceProvider().GetRequiredService<ICustomCommandValidator>().ValidateAsync(command).ConfigureAwait(false);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.Severity == Severity.Error && x.ErrorCode == "NotEmptyValidator" && x.PropertyName == nameof(CustomCommand.CommandWord));
        }
    }
}
