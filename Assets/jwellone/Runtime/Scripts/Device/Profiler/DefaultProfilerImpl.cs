#nullable enable

namespace jwellone
{
    public sealed class DefaultProfilerImpl : IMemoryProfiler
    {
        long IMemoryProfiler.useMemorySize
        {
            get
            {
                return 0;
            }
        }
    }
}