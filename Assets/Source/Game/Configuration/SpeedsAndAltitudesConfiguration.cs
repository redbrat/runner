using UnityEngine;

namespace Source.Game.Configuration
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(SpeedsAndAltitudesConfiguration), fileName = nameof(SpeedsAndAltitudesConfiguration), order = 0)]
    public class SpeedsAndAltitudesConfiguration : ScriptableObject
    {
        public float InitialSpeed => initialSpeed;
        [SerializeField] private float initialSpeed = 5f;
        public float InitialAltitude => initialAltitude;
        [SerializeField] private float initialAltitude = 0f;
        public float FlyDuration => flyDuration;
        [SerializeField] private float flyDuration = 10f;
        public float FlyAltitudeValue => flyAltitudeValue;
        [SerializeField] private float flyAltitudeValue = 3f;
        public float SpeedUpDuration => speedUpDuration;
        [SerializeField] private float speedUpDuration = 10f;
        public float SpeedUpValue => speedUpValue;
        [SerializeField] private float speedUpValue = 3f;
        public float SlowDownDuration => slowDownDuration;
        [SerializeField] private float slowDownDuration = 10f;
        public float SlowDownValue => slowDownValue;
        [SerializeField] private float slowDownValue = 2f;
    }
}
