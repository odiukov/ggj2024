namespace Player
{
    using System;
    using Audience;
    using Cysharp.Threading.Tasks;
    using Gameplay.Game.Services;
    using Minigames;
    using UnityEngine;
    using Zenject;

    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator Animator;
        [SerializeField] private Animator CurAnimator;
        
        [Inject]
        IAlertService AlertService { get; set; }

        [Inject] public SoundService SoundService { get; set; }
        
        [Inject]
        ICrashProvider CrashProvider { get; set; }
        
        [Inject]
        IPlayerHP PlayerHP { get; set; }

        private void Start()
        {
            AlertService.Refresh += OnRefresh;
            PlayerHP.HPChanged += OnHPChanged;
            Animator.SetTrigger("Joking");
        }

        private async void OnHPChanged(float hp)
        {
            if(hp <= 0)
            {
                SoundService.Stop(SoundEffect.Applause);
                SoundService.Play(SoundEffect.Death, 0.5f);
                Animator.SetTrigger("Death");
                await UniTask.WaitForSeconds(0.5f);
                CurAnimator.SetTrigger("Close");
            }
        }

        private void OnRefresh()
        {
            if (CrashProvider.HasCrash)
            {
                Animator.SetTrigger("Looser");
            }
            else
            {
                Animator.SetTrigger("Joking");
            }
        }
        
        private void OnDestroy()
        {
            AlertService.Refresh -= OnRefresh;
            PlayerHP.HPChanged -= OnHPChanged;
        }
    }
}
