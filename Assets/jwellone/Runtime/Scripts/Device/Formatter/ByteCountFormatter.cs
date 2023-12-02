#nullable enable

namespace jwellone
{
    public sealed class ByteCountFormatter : IByteCountFormatter
    {
        readonly string _format = "0.##";
        readonly string[] _unitCharacters = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };

        public ByteCountFormatter(string[]? unitCharacters = null, string? format = null)
        {
            if (!string.IsNullOrEmpty(format))
            {
                _format = format;
            }

            if (unitCharacters != null && unitCharacters.Length != 0)
            {
                _unitCharacters = unitCharacters;
            }
        }

        string IByteCountFormatter.GetString(long size)
        {
            return FormatText(size, 0);
        }

        string FormatText(double size, int index)
        {
            if (size <= 1024)
            {
                return $"{size.ToString(_format)}{_unitCharacters[index]}";
            }
            return FormatText(size / 1024.0, index + 1);
        }
    }
}