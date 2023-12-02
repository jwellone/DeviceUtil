using System.Collections;
using System.IO;
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
            var storage = DeviceUtil.storage;

            sb.AppendLine("■freeDiskSpace");
            sb.AppendLine(storage.freeDiskSpaceText);
            sb.AppendLine();

            sb.AppendLine("■totalDiskSpace");
            sb.AppendLine(storage.totalDiskSpaceText);
            sb.AppendLine();

            var profiler = DeviceUtil.profiler;
            sb.AppendLine("■fps");
            sb.AppendLine(profiler.fps.ToString("#.##"));
            sb.AppendLine();

            sb.AppendLine("■Memory");
            sb.Append("Use : ").AppendLine(profiler.useMemorySizeText);
            sb.Append("Total : ").AppendLine(profiler.totalMemorySizeText);
            sb.AppendLine();

            _text.text = sb.ToString();
        }
    }
}