using Audience;
using Core;
using Minigames;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMiniGameRunner>().To<MiniGameRunner>().AsSingle();
        Container.Bind<IWindowOpener>().To<WindowOpener>().AsSingle();
        Container.Bind(typeof(ITickable), typeof(IInitializable), typeof(IAudienceInvolvement))
            .To<AudienceInvolvement>().AsSingle();
        Container.Bind(typeof(ITickable), typeof(IEmotionsProvider)).To<EmotionsProvider>().AsSingle();
        Container.Bind(typeof(ITickable), typeof(ICrashProvider)).To<CrashProvider>().AsSingle();
        Container.Bind(typeof(IEmotionsIconProvider), typeof(IInitializable)).To<EmotionsIconProvider>().AsSingle();
    }
}