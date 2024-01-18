using UnityEngine;
using Zenject;

namespace Source.Game.Track
{
    /// <summary>
    /// This class controls the section of the track that will be actually shown
    /// </summary>
    public class TrackSectionVisibilityController : MonoBehaviour
    {
        [Inject] private readonly TrackScroller trackScroller;
        [Inject] private readonly Track track;
        [Inject] private readonly GameManager gameManager;
        [Inject(Id = "TrackLength")] private readonly int trackLength;

        [SerializeField, Tooltip("How far the section should be behind in order for us to return it to pool")]
        private float sectionRemoveThreshold = 0;
        [SerializeField, Tooltip("The view distance of the track")] private float mustShowDistance = 100;

        private int currentMinSectionVisible;
        private int currentMaxSectionVisible;

        private void OnEnable()
        {
            OnDistanceChanged(trackScroller.CurrentDistance);
            trackScroller.DistanceChanged += OnDistanceChanged;
        }
        
        private void OnDisable()
        {
            trackScroller.DistanceChanged -= OnDistanceChanged;
        }

        private void OnDistanceChanged(float currentDistance)
        {
            if (track.CurrentFarthestSectionDelta - trackScroller.CurrentDistance > mustShowDistance)
            {
                return;
            }

            currentMaxSectionVisible += 1;

            if (trackScroller.CurrentDistance - track.CurrentNearestSectionDelta > sectionRemoveThreshold)
            {
                currentMinSectionVisible += 1;
            }
            
            track.ShowSections(currentMinSectionVisible, currentMaxSectionVisible);
            
            if (currentMinSectionVisible == trackLength)
            {
                gameManager.FinishTheGame();
            }
        }
    }
}
