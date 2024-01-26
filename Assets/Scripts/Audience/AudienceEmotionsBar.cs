namespace Audience
{
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class AudienceEmotionsBar : MonoBehaviour
    {
        [Inject] public IEmotionsEventEmitter EmotionsEventEmitter { get; set; }

        [SerializeField] private Slider slider;

        private void Start()
        {
            EmotionsEventEmitter.EmotionChanged += SetEmotion;
        }

        private void SetEmotion(float value)
        {
            slider.value = value;
        }

        private void OnDestroy()
        {
            EmotionsEventEmitter.EmotionChanged -= SetEmotion;
        }
    }
}