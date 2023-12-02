using UnityEngine;

#nullable enable

namespace jwellone
{
    internal sealed class Profiler
    {
        class ProfilerBehaviour : MonoBehaviour, IProfiler
        {
            int _count;
            float _elapsedTime;
            float _fps;
            readonly IByteCountFormatter _formatter = new ByteCountFormatter();
#if UNITY_EDITOR
            readonly IMemoryProfiler _memoryProfiler = new DefaultProfilerImpl();
#elif UNITY_IOS
            readonly IMemoryProfiler _memoryProfiler = new IOSProfilerImpl();
#elif UNITY_ANDROID
            readonly IMemoryProfiler _memoryProfiler = new AndroidProfilerImpl();
#else
            readonly IMemoryProfiler _memoryProfiler = new DefaultProfilerImpl();
#endif

            float IProfiler.fps => _fps;
            long IMemoryProfiler.useMemorySize => _memoryProfiler.useMemorySize;
            string IProfiler.useMemorySizeText => _formatter.GetString(_memoryProfiler.useMemorySize);

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

        public delegate IProfiler CreateFunction();
        public static CreateFunction? createFunction { get; set; }

        public static IProfiler Create()
        {
            return createFunction?.Invoke() ?? new GameObject("Profiler").AddComponent<ProfilerBehaviour>();
        }
    }
}