#if UNITY_IOS
using System.Runtime.InteropServices;
using UnityEngine.iOS;

#nullable enable

namespace jwellone
{
    internal sealed class IOSStorageImpl : Storage
    {
        [DllImport("__Internal")]
        static extern long getFreeDiskSpace();

        [DllImport("__Internal")]
        static extern long getTotalDiskSpace();

        public override long freeDiskSpace => getFreeDiskSpace();

        public override long totalDiskSpace => getTotalDiskSpace();

        public override void SetNoBackupFlag(string path)
        {
            Device.SetNoBackupFlag(path);
        }
    }
}
#endif