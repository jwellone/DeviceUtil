#if UNITY_IOS
using System.Runtime.InteropServices;

#nullable enable

namespace jwellone
{
    public sealed class IOSMemoryProfiler : IMemoryProfiler
    {
        [DllImport("__Internal")]
        static extern uint getUsedMemorySize();

        [DllImport("__Internal")]
        static extern uint getTotalMemorySize();

        long IMemoryProfiler.useMemorySize => getUsedMemorySize();
        long IMemoryProfiler.totalMemorySize => getTotalMemorySize();
    }
}
#endif