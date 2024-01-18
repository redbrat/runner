using System;
using JetBrains.Annotations;
using Source.Game.Input;
using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    [UsedImplicitly]
    public class ChangeLaneController
    {
        public event Action<int> LaneChanged;

        private int lane;

        [Inject]
        private void Init(IHorizontalInputController horizontalInputController)
        {
            horizontalInputController.HorizontalInput += ChangeLane;
        }

        private void ChangeLane(int value)
        {
            var newLane = Mathf.Clamp(lane + value, -1, 1);
            if (newLane == lane)
            {
                return;
            }
            
            lane = newLane;
            LaneChanged?.Invoke(lane);
        }
    }
}
