namespace ChatterBot.Interfaces
{
    public interface IPluginFactory
    {
        IPlugin CreatePlugin(IPluginUtilities utilities);
    }
}