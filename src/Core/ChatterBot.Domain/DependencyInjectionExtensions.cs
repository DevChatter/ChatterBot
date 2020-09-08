﻿using ChatterBot.Auth;
using ChatterBot.Config;
using ChatterBot.Domain.Auth;
using ChatterBot.Domain.Plugins;
using ChatterBot.Domain.State;
using ChatterBot.Interfaces;
using ChatterBot.State;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDomain(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddSingleton<IDataProtection>(new DataProtection(appSettings));

            services.AddSingleton<ITwitchAuthentication, TwitchAuthentication>();
            services.AddSingleton<IMainMenuItemsSet, MainMenuItemsSet>();
            services.AddSingleton<IMessageHandlerSet, MessageHandlerSet>();
            services.AddSingleton<IPluginSet, PluginSet>();

            services.AddSingleton<IPluginUtilities, PluginUtilities>();

            services.AddTransient<IPluginInitialization, PluginInitialization>();
        }
    }
}