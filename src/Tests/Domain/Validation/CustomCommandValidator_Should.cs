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
        public async Task Return_IsValid_GivenAValidCurrency()
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
    }
}
