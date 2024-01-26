namespace Minigames
{
    using System;
    using JetBrains.Annotations;
    using Sirenix.OdinInspector;
    using Sirenix.Serialization;
    using Zenject;

    public class MiniGameAlerter : SerializedMonoBehaviour
    {
        [Inject] public DiContainer DiContainer { get; set; }
        
        [OdinSerialize]
        private IMiniGame _miniGame;

        private void Start()
        {
            DiContainer.Inject(_miniGame);
        }

        [UsedImplicitly]
        public void OnClick()
        {
            _miniGame.Run();
        }
    }
}