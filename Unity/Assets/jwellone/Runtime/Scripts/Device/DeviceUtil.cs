#nullable enable

namespace jwellone
{
    public static class DeviceUtil
    {
        public delegate IStorageProvider StorageProviderCreate();
        public static StorageProviderCreate createStorageProvider { get; set; } = DefaultStorageProvider.Create;

        public delegate IProfilerProvider ProfilderProviderCreate();
        public static ProfilderProviderCreate createProfilerProvider { get; set; } = DefaultProfilerProvider.Create;

        static IStorageProvider? _storageProvider;
        static IProfilerProvider? _profilerProvider;

        public static IStorageProvider storage => _storageProvider ??= createStorageProvider.Invoke();
        public static IProfilerProvider profiler => _profilerProvider ??= createProfilerProvider.Invoke();

        public static void SetNoBackup(string path)
        {
            storage.SetNoBackupFlag(path);
        }
    }
}