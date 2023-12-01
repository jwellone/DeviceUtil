#nullable enable

namespace jwellone
{
    public static class DeviceUtil
    {
        public readonly static Storage storage = Storage.Create();

        public static void SetNoBackup(string path)
        {
            storage.SetNoBackupFlag(path);
        }
    }
}