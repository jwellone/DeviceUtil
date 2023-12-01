#if UNITY_ANDROID
using UnityEngine;

#nullable enable

namespace jwellone
{
    internal sealed class AndroidStorageImpl : Storage
    {
        readonly AndroidJavaObject _statFs = new AndroidJavaObject("android.os.StatFs", Application.temporaryCachePath);

        ~AndroidStorageImpl()
        {
            _statFs.Dispose();
        }

        long _blockSize => _statFs.Call<long>("getBlockSizeLong");

        public override long freeDiskSpace => _statFs.Call<long>("getAvailableBlocksLong") * _blockSize;
        public override long totalDiskSpace => _statFs.Call<long>("getBlockCountLong") * _blockSize;
    }
}
#endif