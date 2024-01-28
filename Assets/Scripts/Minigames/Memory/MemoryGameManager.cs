namespace Minigames.Fifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class MemoryGameManager : MonoBehaviour
    {
        [SerializeField] private MemoryCard cardPrefab;
        [SerializeField] private MemoryGameWindow window;

        List<MemoryCard> cards = new List<MemoryCard>();

        public int RowCount = 3;
        public float SizeX = 0.3f;
        public float SizeY = 0.3f;

        List<int> combinationIndexes = new List<int>();
        List<int> userCombinationIndexes = new List<int>();

        public int combinationCount;

        public static bool remembering;

        private void Start()
        {
            remembering = false;
            var index = 0;
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    var localI = index;
                    var card = Instantiate(cardPrefab, transform);
                    card.Index = localI;
                    card.Plaing += OnCardPlaing;
                    card.transform.localPosition = new Vector3((j * SizeX), (i * SizeY), 0);
                    cards.Add(card);
                    index++;
                }
            }

            CreateCombination();
            PlayCombination();
        }

        private void OnCardPlaing(int index)
        {
            if (remembering)
            {
                return;
            }

            userCombinationIndexes.Add(index);
            if (userCombinationIndexes.Count == combinationIndexes.Count)
            {
                CheckCombinations();
            }
        }

        private async void CheckCombinations()
        {
            for (var i = 0; i < combinationIndexes.Count; i++)
            {
                if (combinationIndexes[i] == userCombinationIndexes[i])
                {
                    continue;
                }

                CreateCombination();
                PlayCombination();
                return;
            }

            window.InternalClose();
        }

        private async void PlayCombination()
        {
            remembering = true;
            await UniTask.WaitForSeconds(MemoryCard.ShowInterval);
            foreach (var index in combinationIndexes)
            {
                await cards.FirstOrDefault(x => x.Index == index).Play();
            }

            userCombinationIndexes.Clear();
            remembering = false;
        }

        public void CreateCombination()
        {
            combinationIndexes.Clear();
            for (var i = 0; i < combinationCount; i++)
            {
                var randomCardIndex = UnityEngine.Random.Range(0, cards.Count - 1);
                combinationIndexes.Add(randomCardIndex);
            }
        }
    }
}