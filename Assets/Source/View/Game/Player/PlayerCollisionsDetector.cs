using Cysharp.Threading.Tasks;
using Source.View.Game.Coins;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Player
{
    public class PlayerCollisionsDetector : MonoBehaviour
    {
        [Inject] private readonly PlayerBehaviourContext context;
        
        private void OnTriggerEnter(Collider collider)
        {
            var coinView = collider.GetComponent<CoinView>();
            if (coinView == null)
            {
                return;
            }
            
            coinView.Consume();
            
            var effects = coinView.Effects;
            if (effects == null)
            {
                return;
            }

            foreach (var effect in effects)
            {
                ProcessEffect(effect);
            }
        }

        private async UniTask ProcessEffect(ICoinEffect effect)
        {
            effect.ApplyEffect(context);
            await UniTask.WaitForSeconds(effect.EffectDuration);
            effect.RemoveEffect(context);
        }
    }
}
