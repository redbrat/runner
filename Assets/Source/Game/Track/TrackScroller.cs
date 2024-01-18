using System;
using Source.Game.Player;
using UnityEngine;
using Zenject;

namespace Source.Game.Track
{
    public class TrackScroller : MonoBehaviour
    {
        public float CurrentDistance => -currentPosition.z;
        public event Action<float> DistanceChanged; 

        [Inject] private readonly PlayerBehaviourContext playerBehaviourContext;
        [Inject] private readonly GameManager gameManager;

        [SerializeField] private Transform trackTransform;

        private Vector3 currentPosition;

        private void Start()
        {
            currentPosition = trackTransform.position;
        }

        private void Update()
        {
            if (gameManager.GameIsFinished == true)
            {
                return;
            }
            currentPosition = new Vector3(currentPosition.x, -playerBehaviourContext.Altitude,
                currentPosition.z - Time.deltaTime * playerBehaviourContext.Speed);
            trackTransform.position = currentPosition;
            DistanceChanged?.Invoke(CurrentDistance);
        }
    }
}
