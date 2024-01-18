using UnityEngine;

namespace Source.View.Game.Configuration
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(CoinFrequencyConfiguration), fileName = nameof(CoinFrequencyConfiguration), order = 0)]
    public class CoinFrequencyConfiguration : ScriptableObject
    {
        public int SimpleCoinFraction => simpleCoinFraction;
        [SerializeField] private int simpleCoinFraction;
        public int SpeedUpCoinFraction => speedUpCoinFraction;
        [SerializeField] private int speedUpCoinFraction;
        public int SlowDownCoinFraction => slowDownCoinFraction;
        [SerializeField] private int slowDownCoinFraction;
        public int FlyCoinFraction => flyCoinFraction;
        [SerializeField] private int flyCoinFraction;
    }
}