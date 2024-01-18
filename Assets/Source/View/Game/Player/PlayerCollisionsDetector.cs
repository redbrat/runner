using Cysharp.Threading.Tasks;
using Source.View.Game.Coins;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Player
{
    public class PlayerCollisionsDetector : MonoBehaviour
    {
        [Inject] private readonly PlayerBehaviourContext context;
        
        private void OnCollisionEnter(Collision collision)
        {
            var coinView = collision.gameObject.GetComponent<CoinView>();
            if (coinView == null)
            {
                return;
            }

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
