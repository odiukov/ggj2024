namespace Minigames.Fifteen
{
    using System;
    using Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class FifteenMiniGameWindow : Window
    {
        [SerializeField] private GameObject checker;

        private void Start()
        {
            checker.SetActive(false);
        }

        public async void InternalClose()
        {
            checker.SetActive(true);
            await UniTask.Delay(1000);
            Close();
        }

        public async UniTask<MiniGameResult> WaitForResult()
        {
            await WaitUntilClosed();
            return MiniGameResult.Success;
        }
    }
}