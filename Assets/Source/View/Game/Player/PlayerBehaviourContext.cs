using JetBrains.Annotations;

namespace Source.View.Game.Player
{
    [UsedImplicitly]
    public class PlayerBehaviourContext
    {
        public float Altitude { get; private set; }
        public float Speed { get; private set; }
        
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
