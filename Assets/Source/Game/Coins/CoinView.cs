using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Source.Game.Coins
{
    public class CoinView : MonoBehaviour
    {
        [Inject] private readonly GameModel gameModel;
        
        [SerializeField, Tooltip("360 rotation time")] private float rotationDuration = 2f;

        public IEnumerable<ICoinEffect> Effects => effects;
        [InjectOptional] private readonly IEnumerable<ICoinEffect> effects;

        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * (360 / rotationDuration));
        }

        public void Consume()
        {
            gameObject.SetActive(false);
            gameModel.Add1Score();
        }

        [UsedImplicitly]
        public class Pool : MonoMemoryPool<Transform, CoinView>
        {
            protected override void Reinitialize(Transform parent, CoinView item)
            {
                var itemTransform = item.transform;
                itemTransform.SetParent(parent);
                itemTransform.localPosition = Vector3.zero;
                itemTransform.localRotation = Quaternion.identity;
                itemTransform.localScale = Vector3.one;
            }
        }
    }
}
