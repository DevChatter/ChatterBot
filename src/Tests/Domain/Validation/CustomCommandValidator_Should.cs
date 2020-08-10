using System.Threading.Tasks;
using ChatterBot.Core.Config;
using ChatterBot.Core.SimpleCommands;
using ChatterBot.Domain.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ChatterBot.Tests.Domain.Validation
{
    public class CustomCommandValidator_Should
    {
        private readonly ApplicationSettings fakeAppSettings = new ApplicationSettings() { Entropy = "SomeFakedEntropyString", LightDbConnection = "Filename=database.db;Password=1234" };

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_IsValid_GivenAValidCustomCommand()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddDomain(this.fakeAppSettings);

            var command = new CustomCommand();

            // Act
            var result = await services.BuildServiceProvider().GetRequiredService<ICustomCommandValidator>().ValidateAsync(command).ConfigureAwait(false);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_ValidationError_GivenACustomCommand_WithoutAZeroLengthCommandWord()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddDomain(this.fakeAppSettings);

            var command = new CustomCommand() { CommandWord = string.Empty };

            // Act
            var result = await services.BuildServiceProvider().GetRequiredService<ICustomCommandValidator>().ValidateAsync(command).ConfigureAwait(false);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.Severity == Severity.Error && x.ErrorCode == "NotEmptyValidator" && x.PropertyName == nameof(CustomCommand.CommandWord));
        }


        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_ValidationError_GivenACustomCommand_WithoutACommandWordThatDoseNotStartWithAnExclamation()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddDomain(this.fakeAppSettings);

            var command = new CustomCommand() { CommandWord = "MyCommandWord" };

            // Act
            var result = await services.BuildServiceProvider().GetRequiredService<ICustomCommandValidator>().ValidateAsync(command).ConfigureAwait(false);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.Severity == Severity.Error && x.ErrorCode == "PredicateValidator" && x.PropertyName == nameof(CustomCommand.CommandWord));
        }
    }
}
