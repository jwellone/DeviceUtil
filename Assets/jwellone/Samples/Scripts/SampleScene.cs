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

            sb.AppendLine("◼︎freeDiskSpace");
            sb.AppendLine(storage.freeDiskSpaceText);
            sb.AppendLine();
            sb.AppendLine("◼︎totalDiskSpace");
            sb.AppendLine(storage.totalDiskSpaceText);

            _text.text = sb.ToString();
        }
    }
}