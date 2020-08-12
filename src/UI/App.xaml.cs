using ChatterBot.Interfaces;
using ChatterBot.State;
using ChatterBot.UI.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows;

namespace ChatterBot.UI
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            var uri = new UriBuilder("http", "localhost", 1111).Uri;
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

            InitializeMenus(provider);

            var plugins = provider.GetServices<IPlugin>();
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
            var menuItemsSet = provider.GetService<IMainMenuItemsSet>();
            var menuItems = provider.GetServices<IMenuItemViewModel>().ToArray();
            menuItemsSet.Initialize(menuItems.Where(x => !x.IsOption), menuItems.Where(x => x.IsOption));
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
