namespace Minigames
{
    using System;
    using JetBrains.Annotations;
    using Sirenix.OdinInspector;
    using Sirenix.Serialization;
    using UnityEngine;
    using Zenject;

    public class MiniGameAlerter : SerializedMonoBehaviour
    {
        [Inject] public DiContainer DiContainer { get; set; }
        [Inject] public IAlertService AlertService { get; set; }
        public bool IsActive { get; private set; }

        [SerializeField] private Animator _animator;
        
        [OdinSerialize]
        private IMiniGame _miniGame;
        
        private void Start()
        {
            DiContainer.Inject(_miniGame);
        }

        [UsedImplicitly]
        public async void OnMouseDown()
        {
            if (!IsActive)
            {
                return;
            }
            
            var result = await _miniGame.Run();
            if (result == MiniGameResult.Success)
            {
                IsActive = false;
                _animator?.SetTrigger("Normal");
                AlertService.RefreshAlerts();
            }
        }

        public void Activate()
        {
            IsActive = true;
            _animator?.SetTrigger("Alarm");
        }
    }
}