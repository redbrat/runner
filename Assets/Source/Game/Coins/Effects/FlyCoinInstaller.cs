using System.Collections.Generic;
using Source.Game.Configuration;
using Zenject;

namespace Source.Game.Coins.Effects
{
    public class FlyCoinInstaller : MonoInstaller
    {
        [Inject] private readonly SpeedsAndAltitudesConfiguration configuration;

        public override void InstallBindings()
        {
            Container.Bind<IEnumerable<ICoinEffect>>()
                .FromInstance(new[] { new FlyEffect(configuration.FlyDuration, configuration.FlyAltitudeValue) });
        }
    }
}