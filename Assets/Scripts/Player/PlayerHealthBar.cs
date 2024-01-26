namespace Player
{
    using Audience;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class PlayerHealthBar : MonoBehaviour
    {
        [Inject] public IAudienceInvolvement AudienceInvolvement { get; set; }

        [SerializeField] private TMP_Text healthBar;

        [SerializeField] private float maxHealth = 100;

        private float _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
            AudienceInvolvement.ProgressChanged += SetHealth;
        }

        private void SetHealth(string guest, Emotion value)
        {
            _currentHealth = Mathf.Min(maxHealth, _currentHealth + (int)value);
            healthBar.SetText(((int)_currentHealth).ToString());
        }

        private void OnDestroy()
        {
            AudienceInvolvement.ProgressChanged -= SetHealth;
        }
    }
}