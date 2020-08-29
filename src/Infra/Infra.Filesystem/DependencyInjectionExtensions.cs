using ChatterBot.FileSystem;
using ChatterBot.Infra.Filesystem;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructureForFilesystem(this IServiceCollection services)
        {
            services.AddTransient<IDirectoryReader, DirectoryReader>();
        }
    }
}