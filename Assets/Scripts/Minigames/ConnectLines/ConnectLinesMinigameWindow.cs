namespace Minigames
{
    using Core;
    using Cysharp.Threading.Tasks;

    public class ConnectLinesMinigameWindow : Window
    {
        private MiniGameResult _miniGameResult = MiniGameResult.Failure;

        public UniTask<MiniGameResult> WaitForResult()
        {
            return WaitUntilClosed()
                .ContinueWith(() => _miniGameResult);
        }
    }
}