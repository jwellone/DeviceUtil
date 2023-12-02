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
            long IMemoryProfiler.useMemorySize => _memoryProfiler.useMemorySize;
            long IMemoryProfiler.totalMemorySize => _memoryProfiler.totalMemorySize;
            string IProfilerProvider.useMemorySizeText => _formatter.GetString(_memoryProfiler.useMemorySize);
            string IProfilerProvider.totalMemorySizeText => _formatter.GetString(_memoryProfiler.totalMemorySize);

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
        long IMemoryProfiler.useMemorySize => _impl.useMemorySize;
        long IMemoryProfiler.totalMemorySize => _impl.totalMemorySize;
        string IProfilerProvider.useMemorySizeText => _impl.useMemorySizeText;
        string IProfilerProvider.totalMemorySizeText => _impl.totalMemorySizeText;

        DefaultProfilerProvider()
        {
            _impl = new GameObject("Profilder").AddComponent<Behaviour>();
        }

        internal static IProfilerProvider Create()
        {
            return new DefaultProfilerProvider();
        }
    }
}