using System.Collections.Generic;
using Source.View.Game.Coins;
using Source.View.Game.Configuration;
using Source.View.Game.Track;
using UnityEngine;
using Zenject;

namespace Source.View.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform trackRoot;
        [SerializeField] private CoinFrequencyConfiguration.Holder coinFrequencyConfigurationColder;
        [SerializeField] private CoinVisualsConfiguration coinVisualsConfiguration;
        [SerializeField] private TrackSection trackSection;
        [SerializeField] private List<TrackSegmentConfiguration> trackSegmentConfigurations;
        
        public override void InstallBindings()
        {
            Container.Bind<IFactory<int, Track.Track>>().To<Track.Track.Factory>().AsSingle();
            Container.BindInstance(coinFrequencyConfigurationColder.Configuration);
            Container.BindInstance(trackRoot);
            Container.BindInstance(trackSegmentConfigurations);
            Container
                .BindMemoryPool<TrackSection, TrackSection.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(trackSection);
            BindCoinsPool(coinVisualsConfiguration.SimpleCoinPrefab, CoinTypes.Simple, 40);
            BindCoinsPool(coinVisualsConfiguration.FlyCoinPrefab, CoinTypes.Fly, 2);
            BindCoinsPool(coinVisualsConfiguration.SlowDownCoinPrefab, CoinTypes.SlowDown, 2);
            BindCoinsPool(coinVisualsConfiguration.SpeedUpCoinPrefab, CoinTypes.SpeedUp, 2);
        }

        private void BindCoinsPool(GameObject coinPrefab, CoinTypes coinType, int initialPoolSize)
        {
            Container
                .BindMemoryPool<CoinView, CoinView.Pool>()
                .WithId(coinType)
                .WithInitialSize(initialPoolSize)
                .FromComponentInNewPrefab(coinPrefab);
        }
    }
}
