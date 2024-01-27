namespace Minigames.Fifteen
{
    using Core;
    using Cysharp.Threading.Tasks;
    using Zenject;

    public class FifteenMiniGame : IMiniGame
    {
        [Inject] private IWindowOpener WindowOpener { get; set; }

        public UniTask<MiniGameResult> Run()
        {
            var window = WindowOpener.Create<FifteenMiniGameWindow>();
            window.Show();
            return window.WaitForResult();
        }
    }
}