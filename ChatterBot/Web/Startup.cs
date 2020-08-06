using ChatterBot.Core.Config;
using ChatterBot.Infra.Twitch;
using ChatterBot.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatterBot.Web
{
    public class Startup
    {
        public IHostEnvironment HostEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            HostEnvironment = hostEnvironment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddSignalR();

            services.AddMediatR(typeof(Startup));

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AccountsViewModel>();
            services.AddSingleton<TerminalViewModel>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<CommandsViewModel>();
            services.AddSingleton<PluginViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<AccountsWindow>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<TwitchAuthentication>();
            services.AddTransient<TwitchBotViewModel>();
            services.AddTransient<TwitchStreamerViewModel>();

            services.Configure<ApplicationSettings>(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (HostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}