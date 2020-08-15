using ChatterBot.Domain.Plugins;
using ChatterBot.Interfaces;
using ChatterBot.State;
using ChatterBot.UI.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ChatterBot.UI
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            Uri uri = new UriBuilder("http", "localhost", 1111).Uri;
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(
                    builder => builder
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        .UseWebRoot("wwwroot")
                        .ConfigureKestrel((context, options) => { })
                        .UseUrls(uri.AbsoluteUri))
                .Build();

        }

        private async void App_OnStartup(object sender, StartupEventArgs e)
        {
            IServiceProvider provider = _host.Services;

            InitializePlugins(provider);

            InitializeMenus(provider);

            InitializeMessageHandlers(provider);

            IEnumerable<IPlugin> plugins = provider.GetServices<IPlugin>();
            foreach (IPlugin plugin in plugins)
            {
                plugin.Initialize();
            }

            var mainWindow = provider.GetService<MainWindow>();
            Current.MainWindow = mainWindow; // TODO: Confirm if this adds any benefit.
            mainWindow.Show();
            await _host.RunAsync();
        }

        private void InitializeMenus(IServiceProvider provider)
        {
            // TODO: Move this to Domain project
            var menuItemsSet = provider.GetService<IMainMenuItemsSet>();
            var menuItems = provider.GetServices<IMenuItemViewModel>().ToArray();
            menuItemsSet.Initialize(menuItems.Where(x => !x.IsOption), menuItems.Where(x => x.IsOption));
        }

        private void InitializeMessageHandlers(IServiceProvider provider)
        {
            // TODO: Move this to Domain project
            var messageHandlerSet = provider.GetService<IMessageHandlerSet>();
            var messageHandlers = provider.GetServices<IMessageHandler>().ToArray();
            messageHandlerSet.Initialize(messageHandlers);
        }

        private void InitializePlugins(IServiceProvider provider)
        {
            // TODO: Move this to Domain project
            var pluginInitialization = provider.GetService<IPluginInitialization>();
            pluginInitialization.Initialize();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
