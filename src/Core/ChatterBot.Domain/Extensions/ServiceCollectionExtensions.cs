using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatterBot.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWithInterfaces<TConcrete>(this IServiceCollection services, params Type[] types)
            where TConcrete : class
        {
            services.AddSingleton<TConcrete>();
            foreach (Type type in types)
            {
                services.AddSingleton(type, x => x.GetRequiredService<TConcrete>());
            }
        }
    }
}