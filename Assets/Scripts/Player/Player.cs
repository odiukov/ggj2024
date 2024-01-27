namespace Player
{
    using System;
    using Audience;
    using Minigames;
    using UnityEngine;
    using Zenject;

    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator Animator;
        
        [Inject]
        IAlertService AlertService { get; set; }
        
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

        private void OnHPChanged(float hp)
        {
            if(hp <= 0)
                Animator.SetTrigger("Death");
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