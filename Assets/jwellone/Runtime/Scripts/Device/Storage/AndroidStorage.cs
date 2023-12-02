#if UNITY_ANDROID
using UnityEngine;

#nullable enable

namespace jwellone
{
    internal sealed class AndroidStorage : IStorage
    {
        readonly AndroidJavaObject _statFs = new AndroidJavaObject("android.os.StatFs", Application.temporaryCachePath);

        ~AndroidStorage()
        {
            _statFs.Dispose();
        }

        long _blockSize => _statFs.Call<long>("getBlockSizeLong");
        long IStorage.freeDiskSpace => _statFs.Call<long>("getAvailableBlocksLong") * _blockSize;
        long IStorage.totalDiskSpace => _statFs.Call<long>("getBlockCountLong") * _blockSize;
    }
}
#endif