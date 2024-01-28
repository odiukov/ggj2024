namespace Player
{
    using System;
    using Audience;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;
    
    public interface IPlayerHP
    {
        float CurrentHealth { get; }

        bool EndGame { get; }

        event Action<float> HPChanged;
    }

    public class PlayerHealthBar : MonoBehaviour, IPlayerHP
    {
        [Inject] public IAudienceInvolvement AudienceInvolvement { get; set; }

        [SerializeField] private TMP_Text healthBar;

        private float maxHealth = 10;

        private float _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
            AudienceInvolvement.ProgressChanged += SetHealth;
        }

        private void SetHealth(string guest, Emotion value)
        {
            _currentHealth = Mathf.Min(maxHealth, _currentHealth + (int)value);
            if(_currentHealth <= 0)
            {
                _currentHealth = 0;
            }
            healthBar.SetText(((int)_currentHealth).ToString());
            HPChanged?.Invoke(_currentHealth);
        }

        private void OnDestroy()
        {
            AudienceInvolvement.ProgressChanged -= SetHealth;
        }

        public float CurrentHealth => _currentHealth;
        public bool EndGame => _currentHealth <= 0;
        public event Action<float> HPChanged;
    }
}