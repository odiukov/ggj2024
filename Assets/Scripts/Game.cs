namespace DefaultNamespace
{
    using System;
    using Gameplay.Game.Services;
    using Minigames;
    using UnityEngine;
    using Zenject;

    public class Game : MonoBehaviour
    {
        [Inject]
        public IAlertService AlertService { get; set; }
        
        [Inject]
        public SoundService SoundService { get; set; }

        private void Start()
        {
            SoundService.Play(SoundEffect.BackgroundGame, 0.1f, true);
            AlertService.Initialize();
        }
    }
}
