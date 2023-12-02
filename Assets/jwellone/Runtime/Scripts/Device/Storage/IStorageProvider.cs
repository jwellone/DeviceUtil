#nullable enable

namespace jwellone
{
    public interface IStorageProvider : IStorage
    {
        string freeDiskSpaceText { get; }
        string totalDiskSpaceText { get; }
    }
}