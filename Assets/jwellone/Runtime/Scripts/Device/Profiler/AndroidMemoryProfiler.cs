#if UNITY_ANDROID
using System.Diagnostics;
using UnityEngine;

#nullable enable

namespace jwellone
{
    public sealed class AndroidMemoryProfiler : IMemoryProfiler
    {
        readonly AndroidJavaClass _unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        ~AndroidMemoryProfiler()
        {
            _unityPlayer.Dispose();
        }

        long IMemoryProfiler.useMemorySize
        {
            get
            {
                var activity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                var application = activity.Call<AndroidJavaObject>("getApplication");
                var context = application.Call<AndroidJavaObject>("getApplicationContext");
                var service = context.GetStatic<AndroidJavaObject>("ACTIVITY_SERVICE");
                var activityManager = context.Call<AndroidJavaObject>("getSystemService", service);
                var process = Process.GetCurrentProcess();
                var pidList = new int[] { process.Id };
                var memoryInfo = activityManager.Call<AndroidJavaObject[]>("getProcessMemoryInfo", pidList);

                long totalKB = 0;
                foreach (var info in memoryInfo)
                {
                    totalKB += info.Call<int>("getTotalPss");
                }
                return totalKB * 1024;
            }
        }
    }
}
#endif