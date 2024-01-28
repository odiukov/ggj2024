namespace Core
{
    using System;
    using Cysharp.Threading.Tasks;
    using Player;
    using UnityEngine;
    using Zenject;

    public abstract class Window : MonoBehaviour, IWindow
    {
        [Inject] private IPlayerHP _playerHp { get; set; }
        
        UniTaskCompletionSource _completionSource;

        private void Start()
        {
            _playerHp.HPChanged += OnHPChanged;
        }

        private void OnHPChanged(float obj)
        {
            if (_playerHp.EndGame)
            {
                Close();
            }
        }

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