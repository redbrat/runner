using UnityEngine;

namespace Source.Menu
{
    public class CatRotator : MonoBehaviour
    {
        [SerializeField, Tooltip("360 rotation time")] private float rotationDuration = 10f;
        
        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * (360 / rotationDuration));
        }
    }
}
