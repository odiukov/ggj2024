namespace Minigames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Audience;
    using Player;
    using UnityEngine;
    using Zenject;
    using Object = UnityEngine.Object;
    using Random = UnityEngine.Random;

    public interface IAlertService
    {
        void Initialize();
        
        event Action Refresh;
        
        void RefreshAlerts();
        void Starterd();
        void Finished();
    }

    public class AlertService : IAlertService, ITickable, ICrashProvider
    {
        List<MiniGameAlerter> _miniGameAlerters;
        float _timeSinceLastAlert;
        private int step = 3;
        private int currentActivation;
        private int time = 15;
        
        [Inject]
        IPlayerHP PlayerHP { get; set; }

        public void Tick()
        {
            if (PlayerHP.EndGame)
            {
                return;
            }
            
            _timeSinceLastAlert += Time.deltaTime;
            if (_timeSinceLastAlert <= time)
            {
                return;
            }

            _timeSinceLastAlert = 0f;
            Activate();
        }

        private void Activate()
        {
            if (_miniGameAlerters == null || !_miniGameAlerters.Any())
            {
                return;
            }

            var miniGameAlerters = _miniGameAlerters.Where(x => !x.IsActive).ToList();

            if (miniGameAlerters.Count <= 0)
            {
                return;
            }

            currentActivation++;
            if(currentActivation % step == 0)
            {
                time--;
                time = Mathf.Max(5, time);
            }
            var randomAlert =
                miniGameAlerters[Random.Range(0, miniGameAlerters.Count)];
            randomAlert.Activate();
            Refresh?.Invoke();
        }

        public void Initialize()
        {
            _miniGameAlerters = Object.FindObjectsOfType<MiniGameAlerter>().ToList();
        }

        public event Action Refresh;
        public void RefreshAlerts()
        {
            Refresh?.Invoke();
        }

        public void Starterd()
        {
            foreach (var miniGameAlerter in _miniGameAlerters)
            {
                miniGameAlerter.gameObject.SetActive(false);
            }
        }

        public void Finished()
        {
            foreach (var miniGameAlerter in _miniGameAlerters)
            {
                miniGameAlerter.gameObject.SetActive(true);
            }
        }

        public bool HasCrash => _miniGameAlerters != null && _miniGameAlerters.Any(x => x.IsActive);
    }
}
