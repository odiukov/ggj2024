namespace Minigames.SecondGame
{
    using Core;
    using Cysharp.Threading.Tasks;
    using Zenject;

    public class CrackPotsGame : IMiniGame
    {
        
        [Inject] 
        private IWindowOpener WindowOpener { get; set; }

        public UniTask<MiniGameResult> Run()
        {
            var window = WindowOpener.Create<CrackPotsWindow>();
            window.Show();
            return window.WaitForResult();
        }
    }
}