using UnityEngine;
using Zenject;

namespace Source.View.Game.Track
{
    public class TrackInstaller : MonoInstaller
    {
        [Inject] private readonly IFactory<int, Track> trackFactory;

        [SerializeField] private TrackScroller trackScroller;
        [SerializeField, Tooltip("How much section there will be")] private int trackSectionsLength = 100;

        public override void InstallBindings()
        {
            Container.BindInstance(trackScroller);
            Container
                .Bind<Track>()
                .AsSingle()
                .WithArguments(trackSectionsLength)
                .NonLazy();
        }
    }
}
