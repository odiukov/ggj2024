namespace General
{
    using System;
    using Audience;
    using Minigames;
    using UnityEngine;
    using Zenject;

    public class GlobalAlarm : MonoBehaviour
    {
        [SerializeField] private Animator Animator { get; set; }

        [Inject] private IAlertService AlertService { get; set; }
        [Inject] private ICrashProvider CrashProvider { get; set; }

        private void Start()
        {
            AlertService.Refresh += OnRefresh;
        }

        private void OnRefresh()
        {
            if (CrashProvider.HasCrash)
            {
                Animator.SetTrigger("Alarm");
            }
            else
            {
                Animator.SetTrigger("Normal");
            }
        }
    }
}