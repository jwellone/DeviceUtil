#nullable enable

namespace jwellone
{
    public interface IStorage
    {
        long freeDiskSpace => 0L;
        long totalDiskSpace => 0L;
        void SetNoBackupFlag(string path) { }
    }
}