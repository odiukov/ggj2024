namespace Minigames
{
    using Cysharp.Threading.Tasks;
    
    public interface IMiniGameRunner
    {
        UniTask<MiniGameResult> Run(IMiniGame miniGame);
    }

    public class MiniGameRunner : IMiniGameRunner
    {
        public UniTask<MiniGameResult> Run(IMiniGame miniGame)
        {
            return miniGame.Run();
        }
    }

    public interface IMiniGame
    {
        UniTask<MiniGameResult> Run();
    }

    public enum MiniGameResult
    {
        Success,
        Failure
    }
}