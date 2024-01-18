using System.Collections.Generic;
using Source.Game.Coins;
using UnityEngine;

namespace Source.Game.Configuration
{
    public class TrackSegmentConfiguration : MonoBehaviour
    {
        public float SectionLength => sectionLength;
        [SerializeField] private float sectionLength = 27f;
        
        [SerializeField] private Transform[] leftCoins;
        [SerializeField] private Transform[] centralCoins;
        [SerializeField] private Transform[] rightCoins;

        private readonly Dictionary<CoinView, CoinView.Pool> spawnedCoinInstances = new ();

        public void SpawnCoins(List<CoinView.Pool> coinPools)
        {
            foreach (var (spawnedCoin, pool) in spawnedCoinInstances)
            {
                pool.Despawn(spawnedCoin);
            }
            spawnedCoinInstances.Clear();

            var coinsPlaces = GetRandomLane();
            
            foreach (var placeForCoin in coinsPlaces)
            {
                var randomCoinPool = coinPools[Random.Range(0, coinPools.Count)];
                spawnedCoinInstances.Add(randomCoinPool.Spawn(placeForCoin), randomCoinPool);
            }
        }

        private Transform[] GetRandomLane()
        {
            var randomFloat = Random.Range(0f, 1f);
            if (randomFloat > 0.67)
            {
                return leftCoins;
            }

            if (randomFloat > 0.33)
            {
                return centralCoins;
            }

            return rightCoins;
        }
    }
}