namespace Core
{
    using UnityEngine;
    using Zenject;

    public class WindowOpener : IWindowOpener
    {
        // private Canvas root;
        [Inject] private DiContainer DiContainer { get; set; }
        
        public T Create<T>() where T : MonoBehaviour, IWindow
        {
            // if (root == null)
            {
                // root = Object.FindObjectOfType<Canvas>();
            }
            
            var window = Resources.Load<T>(typeof(T).Name);
            window.gameObject.SetActive(false);
            return DiContainer.InstantiatePrefab(window).GetComponent<T>();
        }
    }
}