using UnityEngine.Profiling;

#nullable enable

namespace jwellone
{
    public sealed class DefaultMemoryProfiler : IMemoryProfiler
    {
        long IMemoryProfiler.usedMemorySize => Profiler.GetTotalAllocatedMemoryLong();
        long IMemoryProfiler.availableMemorySize => Profiler.GetTotalUnusedReservedMemoryLong();
        long IMemoryProfiler.totalMemorySize => Profiler.GetTotalReservedMemoryLong();
    }
}