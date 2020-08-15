using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatterBot.Tests
{
    public abstract class BaseTestFixture
    {
        protected ServiceProvider SetUpServices(
            Action<IServiceCollection> configureTestServices)
        {
            var services = new ServiceCollection();
            configureTestServices(services);
            return services.BuildServiceProvider();
        }
    }
}