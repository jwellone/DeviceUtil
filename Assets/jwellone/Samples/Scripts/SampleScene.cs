using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable enable

namespace jwellone.Samples
{
    public class SampleScene : MonoBehaviour
    {
        [SerializeField] Text _text = null!;

        void Update()
        {
            var sb = new StringBuilder();

            var profiler = DeviceUtil.profiler;
            sb.AppendLine("■fps");
            sb.AppendLine(profiler.fps.ToString("#.##"));
            sb.AppendLine();

            sb.AppendLine("■Memory");
            sb.Append("Used : ").AppendLine(profiler.usedMemorySizeText);
            sb.Append("Available : ").AppendLine(profiler.availableMemorySizeText);
            sb.Append("Total : ").AppendLine(profiler.totalMemorySizeText);
            sb.AppendLine();

            var storage = DeviceUtil.storage;

            sb.AppendLine("■Disk Space");
            sb.Append("Used : ").AppendLine(storage.usedDiskSpaceText);
            sb.Append("Available : ").AppendLine(storage.availableDiskSpaceText);
            sb.Append("Total : ").AppendLine(storage.totalDiskSpaceText);
            sb.AppendLine();

            _text.text = sb.ToString();
        }
    }
}