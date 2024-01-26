namespace Minigames
{
    using Zenject;

    public class MiniGamesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<IMiniGame>().To<ConnectLinesMinigame>().AsSingle();
        }
    }
}