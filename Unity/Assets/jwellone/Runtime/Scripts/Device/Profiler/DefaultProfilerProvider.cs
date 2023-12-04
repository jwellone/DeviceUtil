using UnityEngine;

#nullable enable

namespace jwellone
{
    sealed class DefaultProfilerProvider : IProfilerProvider
    {
        class Behaviour : MonoBehaviour, IProfilerProvider
        {
            int _count;
            float _elapsedTime;
            float _fps;
            readonly IByteCountFormatter _formatter = new ByteCountFormatter();
#if UNITY_EDITOR
            readonly IMemoryProfiler _memoryProfiler = new DefaultMemoryProfiler();
#elif UNITY_IOS
            readonly IMemoryProfiler _memoryProfiler = new IOSMemoryProfiler();
#elif UNITY_ANDROID
            readonly IMemoryProfiler _memoryProfiler = new AndroidMemoryProfiler();
#else
            readonly IMemoryProfiler _memoryProfiler = new DefaultMemoryProfiler();
#endif

            float IProfilerProvider.fps => _fps;
            long IMemoryProfiler.usedMemorySize => _memoryProfiler.usedMemorySize;
            long IMemoryProfiler.availableMemorySize => _memoryProfiler.availableMemorySize;
            long IMemoryProfiler.totalMemorySize => _memoryProfiler.totalMemorySize;
            long IMemoryProfiler.unityTotalAllocatedMemorySize => _memoryProfiler.unityTotalAllocatedMemorySize;
            long IMemoryProfiler.unityTotalUnusedReservedMemorySize => _memoryProfiler.unityTotalUnusedReservedMemorySize;
            long IMemoryProfiler.unityTotalReservedMemorySize => _memoryProfiler.unityTotalReservedMemorySize;
            long IMemoryProfiler.monoUsedSize => _memoryProfiler.monoUsedSize;
            long IMemoryProfiler.monoHeapSize => _memoryProfiler.monoHeapSize;
            string IProfilerProvider.usedMemorySizeText => _formatter.GetString(_memoryProfiler.usedMemorySize);
            string IProfilerProvider.availableMemorySizeText => _formatter.GetString(_memoryProfiler.availableMemorySize);
            string IProfilerProvider.totalMemorySizeText => _formatter.GetString(_memoryProfiler.totalMemorySize);
            string IProfilerProvider.unityTotalAllocatedMemorySizeText => _formatter.GetString(_memoryProfiler.unityTotalAllocatedMemorySize);
            string IProfilerProvider.unityTotalUnusedReservedMemorySizeText => _formatter.GetString(_memoryProfiler.unityTotalUnusedReservedMemorySize);
            string IProfilerProvider.unityTotalReservedMemorySizeText => _formatter.GetString(_memoryProfiler.unityTotalReservedMemorySize);
            string IProfilerProvider.monoUsedSizeText => _formatter.GetString(_memoryProfiler.monoUsedSize);
            string IProfilerProvider.monoHeapSizeText => _formatter.GetString(_memoryProfiler.monoHeapSize);

            void Awake()
            {
                DontDestroyOnLoad(gameObject);
            }

            void Update()
            {
                ++_count;
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime < 1f)
                {
                    return;
                }

                _fps = 1.0f * _count / _elapsedTime;

                _count = 0;
                _elapsedTime = 0f;
            }
        }

        readonly IProfilerProvider _impl;
        float IProfilerProvider.fps => _impl.fps;
        long IMemoryProfiler.usedMemorySize => _impl.usedMemorySize;
        long IMemoryProfiler.availableMemorySize => _impl.availableMemorySize;
        long IMemoryProfiler.totalMemorySize => _impl.totalMemorySize;
        long IMemoryProfiler.unityTotalAllocatedMemorySize => _impl.unityTotalAllocatedMemorySize;
        long IMemoryProfiler.unityTotalUnusedReservedMemorySize => _impl.unityTotalUnusedReservedMemorySize;
        long IMemoryProfiler.unityTotalReservedMemorySize => _impl.unityTotalReservedMemorySize;
        long IMemoryProfiler.monoUsedSize => _impl.monoUsedSize;
        long IMemoryProfiler.monoHeapSize => _impl.monoHeapSize;

        string IProfilerProvider.usedMemorySizeText => _impl.usedMemorySizeText;
        string IProfilerProvider.availableMemorySizeText => _impl.availableMemorySizeText;
        string IProfilerProvider.totalMemorySizeText => _impl.totalMemorySizeText;
        string IProfilerProvider.unityTotalAllocatedMemorySizeText => _impl.unityTotalAllocatedMemorySizeText;
        string IProfilerProvider.unityTotalUnusedReservedMemorySizeText => _impl.unityTotalUnusedReservedMemorySizeText;
        string IProfilerProvider.unityTotalReservedMemorySizeText => _impl.unityTotalReservedMemorySizeText;
        string IProfilerProvider.monoUsedSizeText => _impl.monoUsedSizeText;
        string IProfilerProvider.monoHeapSizeText => _impl.monoHeapSizeText;

        DefaultProfilerProvider()
        {
            _impl = new GameObject("Profile").AddComponent<Behaviour>();
        }

        internal static IProfilerProvider Create()
        {
            return new DefaultProfilerProvider();
        }
    }
}