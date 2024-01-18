using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [Inject] private readonly PlayerInputController playerInputController;
        
        private readonly int movingBool = Animator.StringToHash("Moving");
        private readonly int laneSwitchInt = Animator.StringToHash("LaneSwitch");

        [SerializeField] private Animator animator;
        
        private void Start()
        {
            animator.SetBool(movingBool, true);
        }

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
            animator.SetInteger(laneSwitchInt, newLane);
        }
    }
}
