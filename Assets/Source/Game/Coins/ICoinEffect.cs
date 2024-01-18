using Source.Game.Player;

namespace Source.Game.Coins
{
    public interface ICoinEffect
    {
        public float EffectDuration { get; }
        public void ApplyEffect(PlayerBehaviourContext context);
        public void RemoveEffect(PlayerBehaviourContext context);
    }
}
