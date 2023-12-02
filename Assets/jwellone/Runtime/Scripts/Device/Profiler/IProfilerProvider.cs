#nullable enable

namespace jwellone
{
    public interface IProfilerProvider : IMemoryProfiler
    {
        float fps { get; }
        string useMemorySizeText { get; }
        string totalMemorySizeText { get; }
    }
}