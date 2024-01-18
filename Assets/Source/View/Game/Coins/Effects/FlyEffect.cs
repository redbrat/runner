using System;
using Source.View.Game.Player;

namespace Source.View.Game.Coins.Effects
{
    [Serializable]
    public class FlyEffect : ICoinEffect
    {
        public float EffectDuration => duration;
        
        private readonly float duration;
        private readonly float altitudeValue;

        public FlyEffect(float duration, float altitudeValue)
        {
            this.duration = duration;
            this.altitudeValue = altitudeValue;
        }
        
        public void ApplyEffect(PlayerBehaviourContext context)
        {
            context.SetAltitude(context.Altitude + altitudeValue);
        }

        public void RemoveEffect(PlayerBehaviourContext context)
        {
            context.SetAltitude(context.Altitude - altitudeValue);
        }
    }
}
