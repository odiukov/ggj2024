namespace Minigames.Fifteen
{
    using Core;
    using Cysharp.Threading.Tasks;
    using Zenject;

    public class MemoryMiniGame : IMiniGame
    {
        [Inject] private IWindowOpener WindowOpener { get; set; }

        public UniTask<MiniGameResult> Run()
        {
            var window = WindowOpener.Create<MemoryGameWindow>();
            window.Show();
            return window.WaitForResult();
        }
    }
}