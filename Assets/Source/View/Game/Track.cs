using JetBrains.Annotations;
using Zenject;

namespace Source.View.Game
{
    [UsedImplicitly]
    public class Track
    {
        [Inject] private readonly TrackSection.Pool sectionsPool;

        private readonly TrackSection[] trackSections;
        
        public Track(int trackLength)
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
                        sectionsPool.Despawn(trackSections[i]);
                    }
                }
                else
                {
                    trackSections[i] = sectionsPool.Spawn(i);
                }
            }
        }
    }
}
