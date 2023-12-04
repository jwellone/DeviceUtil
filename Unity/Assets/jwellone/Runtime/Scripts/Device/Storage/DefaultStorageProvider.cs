#nullable enable

namespace jwellone
{
    internal sealed class DefaultStorageProvider : IStorageProvider
    {
#if UNITY_EDITOR
        readonly IStorage _impl = new EmptyStorage();
#elif UNITY_ANDROID
        readonly IStorage _impl = new AndroidStorage();
#elif UNITY_IOS
        readonly IStorage _impl = new IOSStorage();
#else
        readonly IStorage _impl = new EmptyStorage();
#endif

        readonly IByteCountFormatter _formatter = new ByteCountFormatter();

        long IStorage.usedDiskSpace => _impl.usedDiskSpace;
        long IStorage.availableDiskSpace => _impl.availableDiskSpace;
        long IStorage.totalDiskSpace => _impl.totalDiskSpace;
        string IStorageProvider.usedDiskSpaceText => _formatter.GetString(_impl.usedDiskSpace);
        string IStorageProvider.availableDiskSpaceText => _formatter.GetString(_impl.availableDiskSpace);
        string IStorageProvider.totalDiskSpaceText => _formatter.GetString(_impl.totalDiskSpace);
        void IStorage.SetNoBackupFlag(string path) => _impl.SetNoBackupFlag(path);

        internal static IStorageProvider Create() => new DefaultStorageProvider();
    }
}