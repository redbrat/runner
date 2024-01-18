using JetBrains.Annotations;
using Source.Game.UI;
using Zenject;

namespace Source.Game.Track
{
    [UsedImplicitly]
    public class Track
    {
        public float CurrentFarthestSectionDelta => currentFarthestSectionDelta;
        public float CurrentNearestSectionDelta => currentNearestSectionDelta;
        
        [Inject] private readonly TrackSection.Pool sectionsPool;

        private TrackSection[] trackSections;
        
        private float currentFarthestSectionDelta;
        private float currentNearestSectionDelta;
        
        [Inject]
        private void Init([Inject(Id = "TrackLength")] int trackLength)
        {
            trackSections = new TrackSection[trackLength];
        }
        
        public void ShowSections(int minSection, int maxSection)
        {
            for (var i = 0; i < trackSections.Length; i++)
            {
                if (i < minSection || i > maxSection)
                {
                    if (trackSections[i] != null)
                    {
                        currentNearestSectionDelta += trackSections[i].GetSectionLength();
                        sectionsPool.Despawn(trackSections[i]);
                        trackSections[i] = null;
                    }
                }
                else if (trackSections[i] == null)
                {
                    var newSegment = sectionsPool.Spawn(currentFarthestSectionDelta);
                    trackSections[i] = newSegment;
                    currentFarthestSectionDelta += newSegment.GetSectionLength();
                }
            }
        }
    }
}
