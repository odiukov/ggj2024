using Core;
using Minigames;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMiniGameRunner>().To<MiniGameRunner>().AsSingle();
        Container.Bind<IWindowOpener>().To<WindowOpener>().AsSingle();
    }
}