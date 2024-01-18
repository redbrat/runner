using System;
using Source.View.Game.Player;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Track
{
    public class TrackScroller : MonoBehaviour
    {
        public float CurrentDistance => -currentPosition.z;
        public event Action<float> DistanceChanged; 

        [Inject] private readonly PlayerBehaviourContext playerBehaviourContext;

        [SerializeField] private Transform trackTransform;

        private Vector3 currentPosition;

        private void Start()
        {
            currentPosition = trackTransform.position;
        }

        private void Update()
        {
            currentPosition = new Vector3(currentPosition.x, -playerBehaviourContext.Altitude,
                currentPosition.z - Time.deltaTime * playerBehaviourContext.Speed);
            trackTransform.position = currentPosition;
            DistanceChanged?.Invoke(CurrentDistance);
        }
    }
}
