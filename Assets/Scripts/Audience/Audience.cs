namespace Audience
{
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    public class Audience : MonoBehaviour
    {
        [Inject] public IEmotionsIconProvider EmotionsIconProvider { get; set; }
        [Inject] public IGuestProvider GuestProvider { get; set; }
        [Inject] public DiContainer Container { get; set; }

        [Inject] public IAudienceInvolvement AudienceInvolvement { get; set; }

        [SerializeField] private Transform iconsContainer;

        [SerializeField] private float xOffSet = 5;
        [SerializeField] private float yOffSet = 2;

        Dictionary<string, GuestView> _guests = new();

        private void Start()
        {
            AudienceInvolvement.ProgressChanged += OnProgressChanged;
            AudienceInvolvement.GuestAdded += OnGuestAdded;
            AudienceInvolvement.Initialize();
        }

        private void OnGuestAdded(string guestId)
        {
            var guest = Container.InstantiatePrefab(GuestProvider.GetRandomGuest()).GetComponent<GuestView>();
            guest.transform.SetParent(iconsContainer);
            guest.transform.position = iconsContainer.position +
                                       new Vector3(UnityEngine.Random.Range(-xOffSet, xOffSet),
                                           UnityEngine.Random.Range(-yOffSet, yOffSet), 0);
            _guests.Add(guestId, guest);
        }

        private void OnProgressChanged(string guest, Emotion emotion)
        {
            _guests[guest].SpawnEmotion(emotion);
        }

        private void OnDestroy()
        {
            AudienceInvolvement.GuestAdded -= OnGuestAdded;
            AudienceInvolvement.ProgressChanged -= OnProgressChanged;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(iconsContainer.transform.position, new Vector3(2 * xOffSet, 2 * yOffSet, 0));
        }
    }
}