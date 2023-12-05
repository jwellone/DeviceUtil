#nullable enable

using System.Diagnostics;

namespace jwellone
{
    public sealed class DefaultMemoryProfiler : IMemoryProfiler
    {
        long IMemoryProfiler.usedMemorySize => Process.GetCurrentProcess().WorkingSet64;
    }
}