namespace Audience
{
    using System;
    using System.Collections.Generic;
    using Zenject;

    public interface IAudienceInvolvement
    {
        event Action<Emotion> ProgressChanged;
    }
    
    public class Guest
    {
        public float AutoIncreaseTime { get; set; }
        public float CurrentTime { get; set; }
    }
    
    public class AudienceInvolvement : IAudienceInvolvement, ITickable, IInitializable
    {
        [Inject] public IEmotionsProvider EmotionsProvider;
        
        private const int AudienceBubbleCount = 3;

        private List<Guest> _guests = new();
        
        public event Action<Emotion> ProgressChanged;

        public void Tick()
        {
            foreach (var guest in _guests)
            {
                if(guest.CurrentTime >= guest.AutoIncreaseTime)
                {
                    guest.CurrentTime = 0;
                    SendEmotion();
                }
                else
                {
                    guest.CurrentTime += UnityEngine.Time.deltaTime;
                }
            }
        }

        private void SendEmotion()
        {
            var emotion = EmotionsProvider.GetEmotion();
            ProgressChanged?.Invoke(emotion);
        }

        public void Initialize()
        {
            for (var i = 0; i < AudienceBubbleCount; i++)
            {
                _guests.Add(new Guest()
                {
                    CurrentTime = UnityEngine.Random.Range(0, 2),
                    AutoIncreaseTime = UnityEngine.Random.Range(3, 10),
                });
            }
        }
    }
}