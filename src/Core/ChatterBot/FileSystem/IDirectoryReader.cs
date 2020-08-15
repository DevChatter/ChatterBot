using System.Collections.Generic;

namespace ChatterBot.FileSystem
{
    public interface IDirectoryReader
    {
        List<string> ReadPluginsFolder();
    }
}