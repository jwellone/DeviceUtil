#nullable enable

namespace jwellone
{
    public abstract class Storage
    {
        public delegate Storage CreateFunction();
        public static CreateFunction? createFunction { get; set; }

        public abstract long freeDiskSpace { get; }
        public abstract long totalDiskSpace { get; }
        public IByteCountFormatter formatter { get; set; } = new ByteCountFormatter();

        public string freeDiskSpaceText => formatter.GetString(freeDiskSpace);
        public string totalDiskSpaceText => formatter.GetString(totalDiskSpace);

        public virtual void SetNoBackupFlag(string path)
        {
        }

        internal static Storage Create()
        {
            if (createFunction != null)
            {
                return createFunction.Invoke();
            }

#if UNITY_EDITOR
            return new EmptyStorageImpl();
#elif UNITY_ANDROID
            return new AndroidStorageImpl();
#elif UNITY_IOS
            return new IOSStorageImpl();
#else
            return new EmptyStorageImpl();
#endif
        }
    }
}