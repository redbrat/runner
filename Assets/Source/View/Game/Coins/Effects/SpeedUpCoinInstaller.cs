using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Coins.Effects
{
    public class SpeedUpCoinInstaller : MonoInstaller
    {
        [SerializeField] private float speedUpDuration = 5f;
        [SerializeField] private float speedUpValue = 1f;

        public override void InstallBindings()
        {
            Container.Bind<IEnumerable<ICoinEffect>>()
                .FromInstance(new[] { new SlowDownEffect(speedUpDuration, speedUpValue) });
        }
    }
}
