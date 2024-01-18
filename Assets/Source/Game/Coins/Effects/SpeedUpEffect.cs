using System;
using Source.Game.Player;

namespace Source.Game.Coins.Effects
{
    [Serializable]
    public class SpeedUpEffect : ICoinEffect
    {
        public float EffectDuration => duration;
        
        private readonly float duration;
        private readonly float speedUpValue;

        public SpeedUpEffect(float duration, float speedUpValue)
        {
            this.duration = duration;
            this.speedUpValue = speedUpValue;
        }
        
        public void ApplyEffect(PlayerBehaviourContext context)
        {
            context.SetSpeed(context.Speed + speedUpValue);
        }

        public void RemoveEffect(PlayerBehaviourContext context)
        {
            context.SetSpeed(context.Speed - speedUpValue);
        }
    }
}
