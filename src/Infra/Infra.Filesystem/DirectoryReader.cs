using ChatterBot.FileSystem;
using System.Collections.Generic;

namespace ChatterBot.Infra.Filesystem
{
    public class DirectoryReader : IDirectoryReader
    {
        public List<string> ReadPluginsFolder()
        {
            return new List<string>();
        }
    }
}
