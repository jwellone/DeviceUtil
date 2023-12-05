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
            sb.Append("\t").AppendLine(profiler.fps.ToString("#.##"));
            sb.AppendLine();

            sb.AppendLine("■Memory");
            sb.AppendLine("- SystemInfo");
            sb.Append("\tSystem\t:\t").AppendLine(profiler.systemMemorySizeText);
            sb.Append("\tGraphics\t:\t").AppendLine(profiler.graphicsMemorySizeText);

            sb.AppendLine("- App");
            sb.Append("\tUsed\t\t:\t").AppendLine(profiler.usedMemorySizeText);
            sb.Append("\tAvailable\t:\t").AppendLine(profiler.availableMemorySizeText);
            sb.Append("\tTotal\t\t\t:\t").AppendLine(profiler.totalMemorySizeText);

            sb.AppendLine("- Unity");
            sb.Append("\tUsed\t\t:\t").AppendLine(profiler.unityTotalAllocatedMemorySizeText);
            sb.Append("\tAvailable\t:\t").AppendLine(profiler.unityTotalReservedMemorySizeText);
            sb.Append("\tTotal\t\t\t:\t").AppendLine(profiler.unityTotalReservedMemorySizeText);

            sb.AppendLine("- Mono");
            sb.Append("\tUsed\t\t:\t").AppendLine(profiler.monoUsedSizeText);
            sb.Append("\tTotal\t\t\t:\t").AppendLine(profiler.monoHeapSizeText);

            sb.AppendLine();

            var storage = DeviceUtil.storage;
            sb.AppendLine("■Disk Space");
            sb.Append("\tUsed\t\t:\t").AppendLine(storage.usedDiskSpaceText);
            sb.Append("\tAvailable\t:\t").AppendLine(storage.availableDiskSpaceText);
            sb.Append("\tTotal\t\t\t:\t").AppendLine(storage.totalDiskSpaceText);
            sb.AppendLine();

            _text.text = sb.ToString();
        }
    }
}