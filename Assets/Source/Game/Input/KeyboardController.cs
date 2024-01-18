using System;
using UnityEngine;

namespace Source.Game.Input
{
    public class KeyboardController : MonoBehaviour, IHorizontalInputController
    {
        public event Action<int> HorizontalInput;
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                HorizontalInput?.Invoke(-1);
            }
            else if(UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                HorizontalInput?.Invoke(1);
            }
        }
    }
}
