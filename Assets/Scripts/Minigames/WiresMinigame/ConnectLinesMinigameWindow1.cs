namespace Minigames
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class ConnectLinesMinigameWindow1 : Window
    {
        [SerializeField] private List<PoweredWireStats> wires;

        [SerializeField] private GameObject checker;

        public static bool Blocked;
        private bool allConnected = false;

        private void Start()
        {
            Blocked = false;
            checker.SetActive(false);
            var items = FindObjectsOfType<PoweredWireBehavior>();
            foreach (var item in items)
            {
                item.MouseUp += ItemsOnMouseUp;
            }
        }

        private void ItemsOnMouseUp()
        {
            CheckWires();
        }

        void CheckWires()
        {
            int count = 0;
            foreach (PoweredWireStats wire in wires)
            {
                if (wire.connected)
                {
                    count++;
                }
            }

            if (count == wires.Count)
            {
                InternalClose();
            }
        }

        private async void InternalClose()
        {
            Blocked = true;
            checker.SetActive(true);
            await UniTask.Delay(1000);
            Close();
        }

        public async UniTask<MiniGameResult> WaitForResult()
        {
            await WaitUntilClosed();
            return MiniGameResult.Success;
        }
    }
}