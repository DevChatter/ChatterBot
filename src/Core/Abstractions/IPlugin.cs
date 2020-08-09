using Microsoft.Extensions.DependencyInjection;

namespace ChatterBot.Core.Interfaces
{
    public interface IPlugin
    {
        void Initialize();
    }
}