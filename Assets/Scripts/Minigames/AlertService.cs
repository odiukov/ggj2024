namespace Minigames
{
    using System.Collections.Generic;
    using System.Linq;
    using Audience;
    using UnityEngine;
    using Zenject;

    public interface IAlertService
    {
        void Initialize();
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
                return;

            var miniGameAlerters = _miniGameAlerters.Where(x => !x.IsActive);

            if (miniGameAlerters.Count() <= 0)
            {
                return;
            }
            
            var randomAlert =
                miniGameAlerters.ToList()[Random.Range(0, _miniGameAlerters.Count - 1)];
            randomAlert.Activate();
        }

        public void Initialize()
        {
            _miniGameAlerters = Object.FindObjectsOfType<MiniGameAlerter>().ToList();
        }

        public bool HasCrash => _miniGameAlerters != null && _miniGameAlerters.Any(x => x.IsActive);
    }
}