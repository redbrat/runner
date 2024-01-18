using System;
using UnityEngine;

namespace Source.Game.Input
{
    public class TouchController : MonoBehaviour, IHorizontalInputController
    {
        public event Action<int> HorizontalInput;
        
        [SerializeField, Tooltip("The minimum distance to consider a gesture swipe")]
        private float minimumSwipeDistance = 75f;
        
        public void OnDelta(Vector2 delta)
        {
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && Mathf.Abs(delta.x) >= minimumSwipeDistance)
            {
                if (delta.x > 0)
                {
                    HorizontalInput?.Invoke(1);
                    return;
                }
                HorizontalInput?.Invoke(-1);
            }
        }
    }
}
