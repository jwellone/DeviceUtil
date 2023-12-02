#nullable enable

namespace jwellone
{
    public sealed class DefaultMemoryProfiler : IMemoryProfiler
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