namespace Minigames.Fifteen
{
    using System;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class MemoryCard : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        
        public static float ShowInterval = .4f;
        
        [HideInInspector]
        public int Index;

        public Color Color;

        public event Action<int> Plaing; 
        public async UniTask Play()
        {
            renderer.color = Color;
            Plaing?.Invoke(Index);
            await UniTask.WaitForSeconds(ShowInterval);
            renderer.color = Color.white;
            await UniTask.WaitForSeconds(ShowInterval);
        }

        private void OnMouseDown()
        {
            if (MemoryGameManager.remembering)
            {
                return;
            }
            Play().Forget();
        }
    }
}