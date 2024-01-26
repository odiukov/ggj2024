namespace Minigames
{
    using Core;
    using Cysharp.Threading.Tasks;
    using Zenject;

    public class ConnectLinesMinigame : IMiniGame
    {
        [Inject] 
        private IWindowOpener WindowOpener { get; set; }

        public UniTask<MiniGameResult> Run()
        {
            var window = WindowOpener.Create<ConnectLinesMinigameWindow>();
            window.Show();
            return window.WaitForResult();
        }
    }
}