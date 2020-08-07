﻿using ChatterBot.Core.Auth;
using ChatterBot.Core.Config;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCore(this IServiceCollection services, ApplicationSettings appSettings)
        {
            services.AddSingleton(new DataProtection(appSettings));
            services.AddSingleton<TwitchAuthentication>();
        }
    }
}