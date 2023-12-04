#nullable enable

namespace jwellone
{
    public interface IStorageProvider : IStorage
    {
        string usedDiskSpaceText { get; }
        string availableDiskSpaceText { get; }
        string totalDiskSpaceText { get; }
    }
}