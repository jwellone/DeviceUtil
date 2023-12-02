#if UNITY_IOS
using System.Runtime.InteropServices;
using UnityEngine.iOS;

#nullable enable

namespace jwellone
{
    internal sealed class IOSStorage : IStorage
    {
        [DllImport("__Internal")]
        static extern long getFreeDiskSpace();

        [DllImport("__Internal")]
        static extern long getTotalDiskSpace();

        long IStorage.freeDiskSpace => getFreeDiskSpace();

        long IStorage.totalDiskSpace => getTotalDiskSpace();

        void IStorage.SetNoBackupFlag(string path)
        {
            Device.SetNoBackupFlag(path);
        }
    }
}
#endif