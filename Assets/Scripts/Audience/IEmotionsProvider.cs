namespace Audience
{
    using UnityEngine;
    using Zenject;

    public interface IEmotionsProvider
    {
        Emotion GetEmotion();
    }

    class EmotionsProvider : IEmotionsProvider, ITickable
    {
        [Inject] public ICrashProvider CrashProvider { get; set; }

        private const float MaxHappines = 3;
        private const float MinHappines = -3;

        private float _currentHappines;

        public Emotion GetEmotion()
        {
            float happines = 0.5f;
            if (_currentHappines > 0.5)
            {
                happines = 0.8f;
            }

            if (_currentHappines < -0.5)
            {
                happines = 0.2f;
            }

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
        }
    }

    public enum Emotion : int
    {
        Happy = 1,
        Sad = -1
    }
}