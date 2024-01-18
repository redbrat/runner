using UnityEngine;

namespace Source.View.Game.Configuration
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(CoinFrequencyConfigurationHolder), fileName = nameof(CoinFrequencyConfigurationHolder), order = 0)]
    public class CoinFrequencyConfigurationHolder : ScriptableObject
    {
        public CoinFrequencyConfiguration Configuration => configuration;
        [SerializeField] private CoinFrequencyConfiguration configuration;
    }
}
