#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long useMemorySize { get; }
        long availableMemorySize { get; }
        long totalMemorySize { get; }
    }
}