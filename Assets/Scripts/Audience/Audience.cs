namespace Audience
{
    using System;
    using UnityEngine;
    using Zenject;

    public class Audience : MonoBehaviour
    {
        [SerializeField]
        Camera camera;
        [Inject] public IEmotionsIconProvider EmotionsIconProvider { get; set; }

        [Inject] public IAudienceInvolvement AudienceInvolvement { get; set; }

        [SerializeField] private Transform iconsContainer;

        [SerializeField] private float xOffSet = 5;
        [SerializeField] private float yOffSet = 2;

        private void Start()
        {
            AudienceInvolvement.ProgressChanged += OnProgressChanged;
        }


        private void Update()
        {
            camera.Render();
        }

        private void OnProgressChanged(Emotion emotion)
        {
            var icon = EmotionsIconProvider.GetIcon(emotion);
            var position =
                new Vector3(UnityEngine.Random.Range(-xOffSet, xOffSet),
                    UnityEngine.Random.Range(-yOffSet, yOffSet), 0);
            var emotionView = Instantiate(icon, iconsContainer.transform);
            emotionView.transform.localPosition = position;
        }

        private void OnDestroy()
        {
            AudienceInvolvement.ProgressChanged -= OnProgressChanged;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(iconsContainer.transform.position, new Vector3(2 * xOffSet, 2 * yOffSet, 0));
        }
    }
}