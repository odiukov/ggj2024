namespace Minigames
{
    using System;
    using Gameplay.Game.Services;
    using JetBrains.Annotations;
    using Sirenix.OdinInspector;
    using Sirenix.Serialization;
    using UnityEngine;
    using Zenject;

    public class MiniGameAlerter : SerializedMonoBehaviour
    {
        [Inject] public DiContainer DiContainer { get; set; }
        [Inject] public IAlertService AlertService { get; set; }
        [Inject] public SoundService SoundService { get; set; }
        public bool IsActive { get; private set; }

        [SerializeField] private Animator _animator;
        
        [OdinSerialize]
        private IMiniGame _miniGame;
        
        private void Start()
        {
            _animator.keepAnimatorStateOnDisable = true;
            DiContainer.Inject(_miniGame);
        }

        [UsedImplicitly]
        public async void OnMouseDown()
        {
            if (!IsActive)
            {
                return;
            }

            SoundService.Play(SoundEffect.StartMinigame, 1.0f);
            AlertService.Starterd();
            _animator?.SetTrigger("Normal");
            var result = await _miniGame.Run();
            AlertService.Finished();
            if (result == MiniGameResult.Success)
            {
                IsActive = false;
                SoundService.Play(SoundEffect.FinishMinigame, 1.0f);
                AlertService.RefreshAlerts();
            }
        }

        public void Activate()
        {
            IsActive = true;
            SoundService.Play(SoundEffect.AlarmMinigame, 1.0f);
            _animator?.SetTrigger("Alarm");
        }
    }
}
