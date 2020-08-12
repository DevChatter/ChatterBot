using ChatterBot.Core.Interfaces;
using ChatterBot.Domain.Validation;
using ChatterBot.Plugins.SimpleCommands;
using ChatterBot.Plugins.SimpleCommands.Validation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSimpleCommandsPlugin(this IServiceCollection services)
        {
            // TODO: Replace this with scanning for IPlugin when loading assemblies
            services.AddSingleton<IPlugin, SimpleCommandsPlugin>();
            services.AddTransient<ICustomCommandValidator, CustomCommandValidator>();
            services.AddSingleton<ICommandsSet, CommandsSet>();
            services.AddSingleton<IMessageHandler, SimpleCommandsMessageHandler>();
        }
    }
}