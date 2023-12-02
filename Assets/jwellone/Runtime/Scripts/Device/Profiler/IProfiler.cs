#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long useMemorySize { get; }
    }

    public interface IProfiler : IMemoryProfiler
    {
        float fps { get; }
        string useMemorySizeText { get; }
    }
}