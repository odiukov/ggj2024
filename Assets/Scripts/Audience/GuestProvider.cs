namespace Audience
{
    using UnityEngine;

    public interface IGuestProvider
    {
        GuestView GetRandomGuest();
    }

    [CreateAssetMenu(menuName = "Create GuestProvider", fileName = "GuestProvider", order = 0)]
    public class GuestProvider : ScriptableObject, IGuestProvider
    {
        [SerializeField] private GuestView[] guests;

        public GuestView GetRandomGuest()
        {
            return guests[Random.Range(0, guests.Length)];
        }
    }
}