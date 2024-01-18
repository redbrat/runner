using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [Inject] private readonly ChangeLaneController playerInputController;
        [Inject] private readonly GameManager gameManager;

        private readonly int movingBool = Animator.StringToHash("Moving");
        private readonly int laneSwitchInt = Animator.StringToHash("LaneSwitch");

        [SerializeField] private Animator animator;
        
        private void Start()
        {
            animator.SetBool(movingBool, true);
        }

        private void OnEnable()
        {
            gameManager.GameFinished += OnGameFinished;
            playerInputController.LaneChanged += OnLaneChanged;
        }

        private void OnDisable()
        {
            playerInputController.LaneChanged -= OnLaneChanged;
            gameManager.GameFinished -= OnGameFinished;
        }

        private void OnGameFinished()
        {
            animator.SetBool(movingBool, false);
        }

        private void OnLaneChanged(int newLane)
        {
            animator.SetInteger(laneSwitchInt, newLane);
        }
    }
}
