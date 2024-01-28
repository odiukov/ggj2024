namespace Audience
{
    using UnityEngine;
    using Zenject;

    public class GuestView : MonoBehaviour
    {
        [Inject] public IEmotionsIconProvider EmotionsIconProvider { get; set; }

        [SerializeField] private Transform emotionHolder;

        public void SpawnEmotion(Emotion emotion)
        {
            var icon = EmotionsIconProvider.GetIcon(emotion);
            Instantiate(icon, emotionHolder);
            icon.transform.localPosition = Vector3.zero;
        }
    }
}