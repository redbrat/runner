using System;
using Source.View.Game.Player;
    
namespace Source.View.Game.Coins.Effects
{
    [Serializable]
    public class SlowDownEffect : ICoinEffect
    {
        public float EffectDuration => duration;
        
        private readonly float duration;
        private readonly float slowDownValue;

        public SlowDownEffect(float duration, float slowDownValue)
        {
            this.duration = duration;
            this.slowDownValue = slowDownValue;
        }
        
        public void ApplyEffect(PlayerBehaviourContext context)
        {
            context.SetSpeed(context.Speed - slowDownValue);
        }

        public void RemoveEffect(PlayerBehaviourContext context)
        {
            context.SetSpeed(context.Speed + slowDownValue);
        }
    }
}
