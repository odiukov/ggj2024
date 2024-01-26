namespace Audience
{
    using UnityEngine;
    using Zenject;

    public interface IEmotionsIconProvider
    {
        GameObject GetIcon(Emotion emotion);
    }

    class EmotionsIconProvider : IEmotionsIconProvider, IInitializable
    {
        GameObject happyIcon;
        GameObject sadIcon;

        public GameObject GetIcon(Emotion emotion)
        {
            switch (emotion)
            {
                case Emotion.Happy:
                    return happyIcon;
                case Emotion.Sad:
                    return sadIcon;
                default:
                    return null;
            }
        }

        public void Initialize()
        {
            happyIcon = Resources.Load<GameObject>("Emotions/Happy");
            sadIcon = Resources.Load<GameObject>("Emotions/Sad");
        }
    }
}