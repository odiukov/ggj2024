namespace Audience
{
    using UnityEngine;
    using Zenject;

    public class GuestView : MonoBehaviour
    {
        [Inject] public IEmotionsIconProvider EmotionsIconProvider { get; set; }

        public void SpawnEmotion(Emotion emotion)
        {
            var icon = EmotionsIconProvider.GetIcon(emotion);
            Instantiate(icon, gameObject.transform);
            icon.transform.localPosition = Vector3.zero;
        }
    }
}