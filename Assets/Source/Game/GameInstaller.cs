using System.Collections.Generic;
using Source.Game.Coins;
using Source.Game.Configuration;
using Source.Game.Input;
using Source.Game.Player;
using Source.Game.Track;
using UnityEngine;
using Zenject;

namespace Source.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SpeedsAndAltitudesConfiguration speedsAndAltitudesConfiguration;
        [SerializeField] private Transform trackRoot;
        [SerializeField] private CoinFrequencyConfiguration coinFrequencyConfiguration;
        [SerializeField] private CoinVisualsConfiguration coinVisualsConfiguration;
        [SerializeField] private TrackSection trackSection;
        [SerializeField] private List<TrackSegmentConfiguration> trackSegmentConfigurations;
        [SerializeField] private TouchController touchController;
        [SerializeField] private KeyboardController keyboardController;
        
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle();
            Container.Bind<GameModel>().AsSingle();
#if UNITY_EDITOR
            Container.Bind<IHorizontalInputController>().FromInstance(keyboardController);
#else
            Container.Bind<IHorizontalInputController>().FromInstance(touchController);
#endif
            Container.Bind<ChangeLaneController>().AsSingle();
            Container.BindInstance(coinFrequencyConfiguration);
            Container.BindInstance(speedsAndAltitudesConfiguration);
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
