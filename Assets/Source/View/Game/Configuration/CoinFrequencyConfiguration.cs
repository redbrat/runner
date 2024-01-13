using System;
using UnityEngine;

namespace Source.View.Game.Configuration
{
    [Serializable]
    public class CoinFrequencyConfiguration
    {
        public int SimpleCoinFraction => simpleCoinFraction;
        [SerializeField] private int simpleCoinFraction;
        public int SpeedUpCoinFraction => speedUpCoinFraction;
        [SerializeField] private int speedUpCoinFraction;
        public int SlowDownCoinFraction => slowDownCoinFraction;
        [SerializeField] private int slowDownCoinFraction;
        public int FlyCoinFraction => flyCoinFraction;
        [SerializeField] private int flyCoinFraction;
        
        [CreateAssetMenu(menuName = "Configs/" + nameof(CoinFrequencyConfiguration) + nameof(Holder), fileName = nameof(CoinFrequencyConfiguration) + nameof(Holder), order = 0)]
        public class Holder : ScriptableObject
        {
            public CoinFrequencyConfiguration Configuration => configuration;
            [SerializeField] private CoinFrequencyConfiguration configuration;
        }
    }
}