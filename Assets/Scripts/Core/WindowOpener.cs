namespace Core
{
    using UnityEngine;

    public class WindowOpener : IWindowOpener
    {
        private Canvas root;
        
        public T Create<T>() where T : MonoBehaviour, IWindow
        {
            if (root == null)
            {
                root = Object.FindObjectOfType<Canvas>();
            }
            
            var window = Resources.Load<T>(typeof(T).Name);
            window.gameObject.SetActive(false);
            return Object.Instantiate(window, root.transform);
        }
    }
}