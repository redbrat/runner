using UnityEngine;

namespace Source.Game.Configuration
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(CoinVisualsConfiguration), fileName = nameof(CoinVisualsConfiguration), order = 0)]
    public class CoinVisualsConfiguration : ScriptableObject
    {
        public GameObject SimpleCoinPrefab => simpleCoinPrefab;
        [SerializeField] private GameObject simpleCoinPrefab;
        public GameObject SpeedUpCoinPrefab => speedUpCoinPrefab;
        [SerializeField] private GameObject speedUpCoinPrefab;
        public GameObject SlowDownCoinPrefab => slowDownCoinPrefab;
        [SerializeField] private GameObject slowDownCoinPrefab;
        public GameObject FlyCoinPrefab => flyCoinPrefab;
        [SerializeField] private GameObject flyCoinPrefab;
    }
}
