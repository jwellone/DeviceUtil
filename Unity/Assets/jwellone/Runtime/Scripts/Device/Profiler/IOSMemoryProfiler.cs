#if UNITY_IOS
using System.Runtime.InteropServices;

#nullable enable

namespace jwellone
{
    public sealed class IOSMemoryProfiler : IMemoryProfiler
    {
        [DllImport("__Internal")]
        static extern long getUsedMemorySize();

        [DllImport("__Internal")]
        static extern long getAvailableMemorySize();

        [DllImport("__Internal")]
        static extern long getTotalMemorySize();

        long IMemoryProfiler.usedMemorySize => getUsedMemorySize();
        long IMemoryProfiler.availableMemorySize => getAvailableMemorySize();
        long IMemoryProfiler.totalMemorySize => getTotalMemorySize();
    }
}
#endif