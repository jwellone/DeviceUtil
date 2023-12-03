#if UNITY_ANDROID
using UnityEngine;

#nullable enable

namespace jwellone
{
    public sealed class AndroidMemoryProfiler : IMemoryProfiler
    {
        readonly int[] _ids = new int[1];
        readonly AndroidJavaObject? _activeManager;
        readonly AndroidJavaObject? _memoryInfo;

        internal AndroidMemoryProfiler()
        {
            using var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            using var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            using var application = activity.Call<AndroidJavaObject>("getApplication");
            using var context = application.Call<AndroidJavaObject>("getApplicationContext");
            using var service = context.GetStatic<AndroidJavaObject>("ACTIVITY_SERVICE");
            using var processClass = new AndroidJavaClass("android.os.Process");
            _activeManager = context.Call<AndroidJavaObject>("getSystemService", service);
            _ids[0] = processClass.CallStatic<int>("myPid");
            _memoryInfo = new AndroidJavaObject("android.app.ActivityManager$MemoryInfo");
        }

        ~AndroidMemoryProfiler()
        {
            _activeManager?.Dispose();
            _memoryInfo?.Dispose();
        }

        long IMemoryProfiler.useMemorySize
        {
            get
            {
                var memoryInfo = _activeManager!.Call<AndroidJavaObject[]>("getProcessMemoryInfo", _ids);
                long totalKB = 0;
                foreach (var info in memoryInfo)
                {
                    totalKB += info.Call<int>("getTotalPss");
                    info.Dispose();
                }
                return totalKB * 1024;
            }
        }

        long IMemoryProfiler.totalMemorySize
        {
            get
            {
                _activeManager!.Call("getMemoryInfo", _memoryInfo);
                return _memoryInfo!.Get<long>("totalMem");
            }
        }
    }
}
#endif