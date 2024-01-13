using System.Collections.Generic;
using UnityEngine;

namespace Source.View.Game.Configuration
{
    public class TrackSegmentConfiguration : MonoBehaviour
    {
        [SerializeField] private Transform[] placesForCoins;

        private readonly Dictionary<CoinView, CoinView.Pool> spawnedCoinInstances = new ();

        public void SpawnCoins(List<CoinView.Pool> coinPools)
        {
            foreach (var (spawnedCoin, pool) in spawnedCoinInstances)
            {
                pool.Despawn(spawnedCoin);
            }
            spawnedCoinInstances.Clear();
            
            foreach (var placeForCoin in placesForCoins)
            {
                var randomCoinPool = coinPools[Random.Range(0, coinPools.Count)];
                spawnedCoinInstances.Add(randomCoinPool.Spawn(placeForCoin), randomCoinPool);
            }
        }
    }
}