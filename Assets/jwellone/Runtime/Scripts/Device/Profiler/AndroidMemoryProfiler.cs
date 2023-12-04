#if UNITY_ANDROID
using UnityEngine;

#nullable enable

namespace jwellone
{
    public sealed class AndroidMemoryProfiler : IMemoryProfiler
    {

        readonly AndroidJavaObject? _plugin;

        internal AndroidMemoryProfiler()
        {
            _plugin = new AndroidJavaObject($"com.jwellone.memory.Memory");
        }

        ~AndroidMemoryProfiler()
        {
            _plugin?.Dispose();
        }

        long IMemoryProfiler.usedMemorySize => _plugin!.CallStatic<long>("getUsedMemorySize");
        long IMemoryProfiler.availableMemorySize => _plugin!.CallStatic<long>("getAvailableMemorySize");
        long IMemoryProfiler.totalMemorySize => _plugin!.CallStatic<long>("getTotalMemorySize");
    }
}
#endif