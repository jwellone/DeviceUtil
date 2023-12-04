#nullable enable

namespace jwellone
{
    public interface IProfilerProvider : IMemoryProfiler
    {
        float fps { get; }
        string usedMemorySizeText { get; }
        string availableMemorySizeText { get; }
        string totalMemorySizeText { get; }
        string unityTotalAllocatedMemorySizeText { get; }
        string unityTotalUnusedReservedMemorySizeText { get; }
        string unityTotalReservedMemorySizeText { get; }
        string monoUsedSizeText { get; }
        string monoHeapSizeText { get; }
    }
}