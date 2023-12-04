using UnityEngine.Profiling;

#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long usedMemorySize { get; }
        long availableMemorySize { get; }
        long totalMemorySize { get; }

        long unityTotalAllocatedMemorySize => Profiler.GetTotalAllocatedMemoryLong();
        long unityTotalUnusedReservedMemorySize => Profiler.GetTotalUnusedReservedMemoryLong();
        long unityTotalReservedMemorySize => Profiler.GetTotalReservedMemoryLong();

        long monoUsedSize => Profiler.GetMonoUsedSizeLong();
        long monoHeapSize => Profiler.GetMonoHeapSizeLong();
    }
}