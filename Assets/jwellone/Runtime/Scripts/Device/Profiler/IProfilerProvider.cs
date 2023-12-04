#nullable enable

namespace jwellone
{
    public interface IProfilerProvider : IMemoryProfiler
    {
        float fps { get; }
        string usedMemorySizeText { get; }
        string availableMemorySizeText { get; }
        string totalMemorySizeText { get; }
    }
}