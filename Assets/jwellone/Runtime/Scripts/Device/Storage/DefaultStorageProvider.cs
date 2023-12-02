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

        long IStorage.freeDiskSpace => _impl.freeDiskSpace;
        long IStorage.totalDiskSpace => _impl.totalDiskSpace;
        string IStorageProvider.freeDiskSpaceText => _formatter.GetString(_impl.freeDiskSpace);
        string IStorageProvider.totalDiskSpaceText => _formatter.GetString(_impl.totalDiskSpace);
        void IStorage.SetNoBackupFlag(string path) => _impl.SetNoBackupFlag(path);

        internal static IStorageProvider Create() => new DefaultStorageProvider();
    }
}