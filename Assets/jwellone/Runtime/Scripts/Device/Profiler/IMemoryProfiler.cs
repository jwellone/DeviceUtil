using UnityEngine.Profiling;

#nullable enable

namespace jwellone
{
    public interface IMemoryProfiler
    {
        long usedMemorySize => 0L;
        long availableMemorySize => 0L;
        long totalMemorySize => 0L;

        long unityTotalAllocatedMemorySize => Profiler.GetTotalAllocatedMemoryLong();
        long unityTotalUnusedReservedMemorySize => Profiler.GetTotalUnusedReservedMemoryLong();
        long unityTotalReservedMemorySize => Profiler.GetTotalReservedMemoryLong();

        long monoUsedSize => Profiler.GetMonoUsedSizeLong();
        long monoHeapSize => Profiler.GetMonoHeapSizeLong();
    }
}