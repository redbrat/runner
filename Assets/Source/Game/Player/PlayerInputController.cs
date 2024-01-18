using System;
using UnityEngine;

namespace Source.Game.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        public event Action<int> LaneChanged; 

        private int lane;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeLane(-1);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeLane(1);
            }
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
