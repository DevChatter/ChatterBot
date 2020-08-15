using ChatterBot.Domain.Plugins;
using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    public interface IPluginSet
    {
        ICollection<PluginInfo> Plugins { get; }
        void Initialize(IEnumerable<PluginInfo> plugins);
        void Register(PluginInfo plugin);
        void UnRegister(PluginInfo plugin);
    }
}
