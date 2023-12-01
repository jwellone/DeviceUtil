#nullable enable

namespace jwellone
{
    public abstract class Storage
    {
        public interface IByteCountFormatter
        {
            string GetString(long size);
        }

        class Formatter : IByteCountFormatter
        {
            readonly static string[] _unitCharacters = new[] { "B", "KB", "MB", "GB", "TB", "PB" };

            string IByteCountFormatter.GetString(long size)
            {
                return FormatText(size, 0);
            }

            string FormatText(double size, int index)
            {
                if (size <= 1024)
                {
                    return $"{size.ToString("0.##")}{_unitCharacters[index]}";
                }
                return FormatText(size / 1024.0, index + 1);
            }
        }

        public delegate Storage CreateFunction();
        public static CreateFunction? createFunction { get; set; }

        public abstract long freeDiskSpace { get; }
        public abstract long totalDiskSpace { get; }
        public IByteCountFormatter formatter { get; set; } = new Formatter();

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