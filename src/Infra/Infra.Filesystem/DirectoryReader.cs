using ChatterBot.FileSystem;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChatterBot.Infra.Filesystem
{
    public class DirectoryReader : IDirectoryReader
    {
        public List<string> ReadPluginsFolder()
        {
            // TODO: Folder name from the settings.
            // TODO: Filesystem access should likely all be async.
            string[] directories = Directory.GetDirectories("Plugins");
            return directories.ToList();
        }
    }
}
