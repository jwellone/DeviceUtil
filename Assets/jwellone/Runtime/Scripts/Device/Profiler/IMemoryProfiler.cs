#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long useMemorySize { get; }
        long totalMemorySize { get; }
    }
}