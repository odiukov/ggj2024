using Audience;
using Core;
using Gameplay.Game.Services;
using Minigames;
using Player;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public GuestProvider GuestProvider;
    public SoundService SoundService;
    public PlayerHealthBar PlayerHealthBar;

    public override void InstallBindings()
    {
        Container.Bind<IMiniGameRunner>().To<MiniGameRunner>().AsSingle();
        Container.Bind<SoundService>().FromInstance(SoundService).AsSingle();
        Container.Bind<IPlayerHP>().FromInstance(PlayerHealthBar).AsSingle();
        Container.Bind(typeof(ITickable), typeof(IAlertService), typeof(ICrashProvider)).To<AlertService>().AsSingle();
        Container.Bind<IWindowOpener>().To<WindowOpener>().AsSingle();
        Container.Bind(typeof(ITickable), typeof(IAudienceInvolvement))
            .To<AudienceInvolvement>().AsSingle();
        Container.Bind(typeof(ITickable), typeof(IEmotionsProvider), typeof(IEmotionsEventEmitter))
            .To<EmotionsProvider>().AsSingle();
        Container.Bind(typeof(IEmotionsIconProvider), typeof(IInitializable)).To<EmotionsIconProvider>().AsSingle();
        Container.Bind<IGuestProvider>().To<GuestProvider>().FromInstance(GuestProvider).AsSingle();
    }
}