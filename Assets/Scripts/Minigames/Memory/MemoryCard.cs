namespace Minigames.Fifteen
{
    using System;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class MemoryCard : MonoBehaviour
    {
        [SerializeField] private GameObject active;
        [SerializeField] private GameObject notActive;
        
        public static float ShowInterval = 1;
        
        [HideInInspector]
        public int Index;

        public event Action<int> Plaing; 
        public async UniTask Play()
        {
            active.SetActive(true);
            notActive.SetActive(false);
            Plaing?.Invoke(Index);
            await UniTask.WaitForSeconds(ShowInterval);
            active.SetActive(false);
            notActive.SetActive(true);
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