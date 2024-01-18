using JetBrains.Annotations;
using Zenject;

namespace Source.View.Game.Track
{
    [UsedImplicitly]
    public class Track
    {
        [Inject] private readonly TrackSection.Pool sectionsPool;

        private readonly TrackSection[] trackSections;
        
        private Track(int trackLength)
        {
            trackSections = new TrackSection[trackLength];
        }
        
        public void ShowSections(int minSection, int maxSection)
        {
            var currentDelta = 0f;
            for (var i = 0; i < trackSections.Length; i++)
            {
                if (i < minSection || i > maxSection)
                {
                    if (trackSections[i] != null)
                    {
                        sectionsPool.Despawn(trackSections[i]);
                    }
                }
                else
                {
                    var newSegment = sectionsPool.Spawn(currentDelta);
                    trackSections[i] = newSegment;
                    currentDelta += newSegment.GetSectionLength();
                }
            }
        }
        
        [UsedImplicitly]
        public class Factory : IFactory<int, Track>
        {
            [Inject] private readonly DiContainer diContainer;
            
            public Track Create(int trackLength)
            {
                return diContainer.Instantiate<Track>(new object[] { trackLength });
            }
        }
    }
}
