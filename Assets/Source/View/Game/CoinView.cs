using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Source.View.Game
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField, Tooltip("360 rotation time")] private float rotationDuration = 2f;

        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * (360 / rotationDuration));
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
