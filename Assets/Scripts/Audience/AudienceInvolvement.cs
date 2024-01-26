namespace Audience
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Zenject;

    public interface IAudienceInvolvement
    {
        void Initialize();
        event Action<string, Emotion> ProgressChanged;
        event Action<string> GuestAdded;
    }

    public class Guest
    {
        public string Id;
        public float AutoIncreaseTime { get; set; }
        public float CurrentTime { get; set; }
    }

    public class AudienceInvolvement : IAudienceInvolvement, ITickable
    {
        [Inject] public IEmotionsProvider EmotionsProvider;

        private const int AudienceBubbleCount = 3;

        private List<Guest> _guests = new();

        public event Action<string, Emotion> ProgressChanged;
        public event Action<string> GuestAdded;

        public void Tick()
        {
            foreach (var guest in _guests)
            {
                if (guest.CurrentTime >= guest.AutoIncreaseTime)
                {
                    guest.CurrentTime = 0;
                    SendEmotion(guest.Id);
                }
                else
                {
                    guest.CurrentTime += UnityEngine.Time.deltaTime;
                }
            }
        }

        private void SendEmotion(string guestId)
        {
            var emotion = EmotionsProvider.GetEmotion();
            ProgressChanged?.Invoke(guestId, emotion);
        }

        public async void Initialize()
        {
            for (var i = 0; i < AudienceBubbleCount; i++)
            {
                var id = Guid.NewGuid().ToString();
                _guests.Add(new Guest()
                {
                    CurrentTime = UnityEngine.Random.Range(0, 2),
                    AutoIncreaseTime = UnityEngine.Random.Range(3, 10),
                    Id = id
                });
                GuestAdded?.Invoke(id);
                await UniTask.Delay(1000);
            }
        }
    }
}