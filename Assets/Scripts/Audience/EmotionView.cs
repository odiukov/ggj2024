namespace Audience
{
    using DG.Tweening;
    using UnityEngine;

    public class EmotionView : MonoBehaviour
    {
        [SerializeField] private float yUpOffsetMax = 5;
        [SerializeField] private float yUpOffsetMin = 3;
        [SerializeField] private float durationMax = 4;
        [SerializeField] private float durationMin = 2;

        private void Start()
        {
            var duration = Random.Range(durationMin, durationMax);
            transform.DOMoveY(transform.position.y + Random.Range(yUpOffsetMin, yUpOffsetMax), duration);
            Destroy(gameObject, duration);
        }
    }
}