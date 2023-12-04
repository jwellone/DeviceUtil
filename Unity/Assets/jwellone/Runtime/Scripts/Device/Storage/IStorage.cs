#nullable enable

namespace jwellone
{
    public interface IStorage
    {
        long usedDiskSpace => 0L;
        long availableDiskSpace => 0L;
        long totalDiskSpace => 0L;
        void SetNoBackupFlag(string path) { }
    }
}