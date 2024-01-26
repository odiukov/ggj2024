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
        [SerializeField] Ease ease = Ease.InOutSine;
        [SerializeField] private Transform art;

        private void Start()
        {
            var duration = Random.Range(durationMin, durationMax);
            transform.DOMoveY(transform.position.y + Random.Range(yUpOffsetMin, yUpOffsetMax), duration).SetEase(ease);
            Destroy(gameObject, duration);

            var sequence = DOTween.Sequence()
                .Append(art.DOLocalRotate(new Vector3(0, 0, 10), .3f))
                .Append(art.DOLocalRotate(new Vector3(0, 0, -10), .3f))
                .SetEase(ease).SetLoops(-1, LoopType.Yoyo);
                ;
        }
    }
}