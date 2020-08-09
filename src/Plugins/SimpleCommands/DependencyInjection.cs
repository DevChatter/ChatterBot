using ChatterBot.Core.Interfaces;
using ChatterBot.Core.SimpleCommands;
using ChatterBot.Domain.Validation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSimpleCommandsPlugin(this IServiceCollection services)
        {
            // TODO: Replace this with scanning for IPlugin when loading assemblies
            services.AddSingleton<IPlugin, SimpleCommandsPlugin>();
            services.AddSingleton<CommandsSet>();
            services.AddTransient<ICustomCommandValidator, CustomCommandValidator>();
        }
    }
}