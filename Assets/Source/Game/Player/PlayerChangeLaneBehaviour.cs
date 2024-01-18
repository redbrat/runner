using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerChangeLaneBehaviour : MonoBehaviour
    {
        [Inject] private readonly PlayerInputController playerInputController;
        
        [SerializeField] private float leftLaneXPosition = -2;
        [SerializeField] private float centralLaneXPosition = 0;
        [SerializeField] private float rightLaneXPosition = 2;

        private void OnEnable()
        {
            playerInputController.LaneChanged += OnLaneChanged;
        }
        
        private void OnDisable()
        {
            playerInputController.LaneChanged -= OnLaneChanged;
        }

        private void OnLaneChanged(int newLane)
        {
            var localPosition = transform.localPosition;
            switch (newLane)
            {
                case -1:
                    transform.localPosition = new Vector3(leftLaneXPosition, localPosition.y, localPosition.z);
                    break;
                case 0:
                    transform.localPosition = new Vector3(centralLaneXPosition, localPosition.y, localPosition.z);
                    break;
                case 1:
                    transform.localPosition = new Vector3(rightLaneXPosition, localPosition.y, localPosition.z);
                    break;
            }
        }
    }
}
