using Source.Game.Configuration;
using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [Inject] private readonly SpeedsAndAltitudesConfiguration speedsAndAltitudesConfiguration;
        
        [SerializeField] private float initialSpeed = 4f;
        [SerializeField] private float initialAltitude = 0f;
        
        public override void InstallBindings()
        {
            var playerBehaviourContext = new PlayerBehaviourContext(speedsAndAltitudesConfiguration.InitialSpeed,
                speedsAndAltitudesConfiguration.InitialAltitude);
            Container.BindInstance(playerBehaviourContext)
                .AsSingle();
        }
    }
}
