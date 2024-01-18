using System.Collections.Generic;
using Source.View.Game.Configuration;
using Zenject;

namespace Source.View.Game.Coins.Effects
{
    public class SpeedUpCoinInstaller : MonoInstaller
    {
        [Inject] private readonly SpeedsAndAltitudesConfiguration configuration;
        
        public override void InstallBindings()
        {
            Container.Bind<IEnumerable<ICoinEffect>>()
                .FromInstance(new[] { new SpeedUpEffect(configuration.SpeedUpDuration, configuration.SpeedUpValue) });
        }
    }
}
