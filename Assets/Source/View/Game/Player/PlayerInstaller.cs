using Source.View.Game.Configuration;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [Inject] private readonly SpeedsAndAltitudesConfiguration speedsAndAltitudesConfiguration;
        
        [SerializeField] private PlayerInputController playerInputController;
        [SerializeField] private float initialSpeed = 4f;
        [SerializeField] private float initialAltitude = 0f;
        
        public override void InstallBindings()
        {
            Container.BindInstance(playerInputController);

            var playerBehaviourContext = new PlayerBehaviourContext(speedsAndAltitudesConfiguration.InitialSpeed,
                speedsAndAltitudesConfiguration.InitialAltitude);
            Container.BindInstance(playerBehaviourContext)
                .AsSingle();
        }
    }
}
