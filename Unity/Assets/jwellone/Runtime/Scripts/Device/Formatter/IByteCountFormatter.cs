#nullable enable

namespace jwellone
{
    public interface IByteCountFormatter
    {
        string GetString(long size);
        string GetString(ulong size);
    }
}