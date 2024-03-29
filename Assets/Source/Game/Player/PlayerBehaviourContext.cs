using JetBrains.Annotations;

namespace Source.Game.Player
{
    [UsedImplicitly]
    public class PlayerBehaviourContext
    {
        public float Altitude { get; private set; }
        public float Speed { get; private set; }

        public PlayerBehaviourContext(float initialSpeed, float initialAltitude)
        {
            Altitude = initialAltitude;
            Speed = initialSpeed;
        }
        
        public void SetSpeed(float newSpeed)
        {
            Speed = newSpeed;
        }

        public void SetAltitude(float newAltitude)
        {
            Altitude = newAltitude;
        }
    }
}
