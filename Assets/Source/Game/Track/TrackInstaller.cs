using UnityEngine;
using Zenject;

namespace Source.Game.Track
{
    public class TrackInstaller : MonoInstaller
    {
        [SerializeField] private TrackScroller trackScroller;
        [SerializeField, Tooltip("How much section there will be")] private int trackSectionsLength = 100;

        public override void InstallBindings()
        {
            Container.BindInstance(trackScroller);
            Container
                .Bind<Source.Game.Track.Track>()
                .AsSingle()
                .WithArguments(trackSectionsLength)
                .NonLazy();
        }
    }
}
