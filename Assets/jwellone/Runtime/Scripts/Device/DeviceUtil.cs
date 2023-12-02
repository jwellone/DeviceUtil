#nullable enable

namespace jwellone
{
    public static class DeviceUtil
    {
        static IProfiler? _profiler;
        static Storage? _storage;

        public static Storage storage => _storage ??= Storage.Create();
        public static IProfiler profiler => _profiler ??= Profiler.Create();

        public static void SetNoBackup(string path)
        {
            storage.SetNoBackupFlag(path);
        }
    }
}