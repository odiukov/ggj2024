namespace Core
{
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public abstract class Window : MonoBehaviour, IWindow
    {
        UniTaskCompletionSource _completionSource;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _completionSource.TrySetResult();
        }

        public UniTask WaitUntilClosed()
        {
            _completionSource = new UniTaskCompletionSource();
            return _completionSource.Task;
        }
    }
}