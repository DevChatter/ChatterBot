﻿using ChatterBot.Domain.Plugins;
using System.Collections.Generic;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    public interface IPluginSet
    {
        BindingList<PluginInfo> Plugins { get; }
        void Register(PluginInfo plugin);
        void UnRegister(PluginInfo plugin);
    }
}