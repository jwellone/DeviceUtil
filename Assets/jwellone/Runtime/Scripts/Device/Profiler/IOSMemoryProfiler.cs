#if UNITY_IOS
using System.Runtime.InteropServices;

#nullable enable

namespace jwellone
{
    public sealed class IOSMemoryProfiler : IMemoryProfiler
    {
        [DllImport("__Internal")]
        static extern uint getUsedMemorySize();

        long IMemoryProfiler.useMemorySize => getUsedMemorySize();
    }
}
#endif