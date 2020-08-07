using ChatterBot;
using ChatterBot.Core.Config;
using ChatterBot.ViewModels;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddUI(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AccountsViewModel>();
            services.AddSingleton<TerminalViewModel>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<CommandsViewModel>();
            services.AddSingleton<PluginViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddTransient<TwitchBotViewModel>();
            services.AddTransient<TwitchStreamerViewModel>();

            services.AddSingleton<AccountsWindow>();
            services.AddSingleton<MainWindow>();
        }
    }
}