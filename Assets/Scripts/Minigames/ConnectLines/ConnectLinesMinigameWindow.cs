namespace Minigames
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class ConnectLinesMinigameWindow : Window
    {
        private MiniGameResult _miniGameResult = MiniGameResult.Failure;

        [SerializeField] private Transform[] startPoints;
        [SerializeField] private Transform[] endPoints;
        [SerializeField] private ConnectLine _linePrefab;

        private void Start()
        {
            var endPos = new List<Transform>(endPoints);
            for (var i = 0; i < startPoints.Length; i++)
            {
                var line = Instantiate(_linePrefab, startPoints[i].position, Quaternion.identity);
                line.transform.SetParent(transform);
                var index = UnityEngine.Random.Range(0, endPos.Count);
                line.SetEnd(endPos[index]);
                endPos.RemoveAt(index);
            }
        }

        public UniTask<MiniGameResult> WaitForResult()
        {
            return WaitUntilClosed()
                .ContinueWith(() => _miniGameResult);
        }
    }
}