namespace Audience
{
    using System;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    public interface IEmotionsProvider
    {
        Emotion GetEmotion();
    }

    public interface IEmotionsEventEmitter
    {
        event Action<float> EmotionChanged;
    }

    class EmotionsProvider : IEmotionsProvider, ITickable, IEmotionsEventEmitter
    {
        [Inject] public ICrashProvider CrashProvider { get; set; }

        private const float MaxHappines = 3;
        private const float MinHappines = -3;

        private float _currentHappines;

        public Emotion GetEmotion()
        {
            var happines = (_currentHappines - MinHappines) / (MaxHappines - MinHappines);
            return Random.value <= happines ? Emotion.Happy : Emotion.Sad;
        }

        public void Tick()
        {
            if (CrashProvider.HasCrash)
            {
                _currentHappines -= Time.deltaTime;
            }
            else
            {
                _currentHappines += Time.deltaTime;
            }

            _currentHappines = Mathf.Clamp(_currentHappines, MinHappines, MaxHappines);
            EmotionChanged?.Invoke(_currentHappines);
        }

        public event Action<float> EmotionChanged;
    }

    public enum Emotion
    {
        Happy = 1,
        Sad = -1
    }
}