namespace Minigames
{
    using Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class ConnectLinesMinigameWindow : Window
    {
        private MiniGameResult _miniGameResult = MiniGameResult.Failure;

        // [SerializeField] private Transform[] connectPoints;

        public UniTask<MiniGameResult> WaitForResult()
        {
            return WaitUntilClosed()
                .ContinueWith(() => _miniGameResult);
        }
    }
}