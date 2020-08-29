using ChatterBot.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChatterBot.Infra.Filesystem
{
    public class DirectoryReader : IDirectoryReader
    {
        // TODO: Make async
        public List<string> ReadPluginsFolder()
        {
            // TODO: Folder name from the settings.
            var pluginsDir = new DirectoryInfo("Plugins");
            return pluginsDir.GetDirectories().Select(dir => dir.Name).ToList();
        }
    }
}
