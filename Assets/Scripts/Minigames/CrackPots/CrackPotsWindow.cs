namespace Minigames.SecondGame
{
    using Core;
    using Cysharp.Threading.Tasks;

    public class CrackPotsWindow : Window
    {
        public async void InternalClose()
        {
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