using UnityEngine.Profiling;

#nullable enable

namespace jwellone
{
    public sealed class DefaultMemoryProfiler : IMemoryProfiler
    {
        long IMemoryProfiler.useMemorySize => Profiler.GetTotalAllocatedMemoryLong();
        long IMemoryProfiler.totalMemorySize => Profiler.GetTotalReservedMemoryLong();
    }
}