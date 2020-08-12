using ChatterBot;
using ChatterBot.Core.Interfaces;
using ChatterBot.Core.State;
using ChatterBot.ViewModels;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddUI(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AccountsViewModel>();
            services.AddSingleton<IMenuItemViewModel, TerminalViewModel>();
            services.AddSingleton<IMenuItemViewModel, AboutViewModel>();
            services.AddSingleton<IMenuItemViewModel, PluginViewModel>();
            services.AddSingleton<IMenuItemViewModel, SettingsViewModel>();
            services.AddTransient<TwitchBotViewModel>();
            services.AddTransient<TwitchStreamerViewModel>();

            services.AddSingleton<AccountsWindow>();
            services.AddSingleton<MainWindow>();
        }
    }
}