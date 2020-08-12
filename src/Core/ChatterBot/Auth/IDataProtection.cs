namespace ChatterBot.Auth
{
    public interface IDataProtection
    {
        byte[] Protect(byte[] data);
        byte[] Unprotect(byte[] data);
    }
}