#nullable enable

namespace jwellone
{
    internal sealed class EmptyStorageImpl : Storage
    {
        public override long freeDiskSpace => 0L;
        public override long totalDiskSpace => 0L;
    }
}