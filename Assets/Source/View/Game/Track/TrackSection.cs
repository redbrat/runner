using System.Collections.Generic;
using JetBrains.Annotations;
using Source.View.Game.Coins;
using Source.View.Game.Configuration;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Track
{
    /// <summary>
    /// A class that holds a random section of a track.
    /// </summary>
    public class TrackSection : MonoBehaviour
    {
        [Inject] private readonly List<TrackSegmentConfiguration> trackSegmentPrefabs;
        
        private TrackSegmentConfiguration segmentInstance;
        
        private void Init()
        {
            segmentInstance = Instantiate(trackSegmentPrefabs[Random.Range(0, trackSegmentPrefabs.Count)], Vector3.zero,
                Quaternion.identity, transform);
        }

        public float GetSectionLength()
        {
            return segmentInstance.SectionLength;
        }

        private void SpawnCoins(List<CoinView.Pool> coinPools)
        {
            segmentInstance.SpawnCoins(coinPools);
        }

        [UsedImplicitly]
        public class Pool : MonoMemoryPool<float, TrackSection>
        {
            private readonly List<CoinView.Pool> coinPools;
            
            [Inject] private readonly Transform trackParent;

            public Pool(CoinFrequencyConfiguration coinFrequencyConfiguration,
                [Inject(Id = CoinTypes.Simple)] CoinView.Pool simpleCoinsPool,
                [Inject(Id = CoinTypes.Fly)] CoinView.Pool flyCoinsPool,
                [Inject(Id = CoinTypes.SlowDown)] CoinView.Pool slowDownCoinsPool,
                [Inject(Id = CoinTypes.SpeedUp)] CoinView.Pool speedUpCoinsPool)
            {
                coinPools = new List<CoinView.Pool>();
                for (var i = 0; i < coinFrequencyConfiguration.SimpleCoinFraction; i++)
                {
                    coinPools.Add(simpleCoinsPool);
                }
                for (var i = 0; i < coinFrequencyConfiguration.FlyCoinFraction; i++)
                {
                    coinPools.Add(flyCoinsPool);
                }
                for (var i = 0; i < coinFrequencyConfiguration.SpeedUpCoinFraction; i++)
                {
                    coinPools.Add(speedUpCoinsPool);
                }
                for (var i = 0; i < coinFrequencyConfiguration.SlowDownCoinFraction; i++)
                {
                    coinPools.Add(slowDownCoinsPool);
                }
            }
            
            protected override void OnCreated(TrackSection item)
            {
                item.Init();
                base.OnCreated(item);
            }

            protected override void Reinitialize(float deltaZ, TrackSection item)
            {
                var itemTransform = item.transform;
                itemTransform.SetParent(trackParent);
                itemTransform.localPosition = Vector3.forward * deltaZ;
                item.SpawnCoins(coinPools);
                base.OnSpawned(item);
            }
        }
    }
}
