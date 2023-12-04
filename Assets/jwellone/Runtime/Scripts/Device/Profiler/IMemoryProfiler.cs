#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long usedMemorySize { get; }
        long availableMemorySize { get; }
        long totalMemorySize { get; }
    }
}