namespace Minigames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Audience;
    using UnityEngine;
    using Zenject;
    using Object = UnityEngine.Object;
    using Random = UnityEngine.Random;

    public interface IAlertService
    {
        void Initialize();
        
        event Action Refresh;
        
        void RefreshAlerts();
    }

    public class AlertService : IAlertService, ITickable, ICrashProvider
    {
        List<MiniGameAlerter> _miniGameAlerters;
        float _timeSinceLastAlert;

        public void Tick()
        {
            _timeSinceLastAlert += Time.deltaTime;
            if (_timeSinceLastAlert <= 5f)
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
            
            var randomAlert =
                miniGameAlerters[Random.Range(0, miniGameAlerters.Count - 1)];
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

        public bool HasCrash => _miniGameAlerters != null && _miniGameAlerters.Any(x => x.IsActive);
    }
}
