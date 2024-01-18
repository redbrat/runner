using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Coins.Effects
{
    public class FlyCoinInstaller : MonoInstaller
    {
        [SerializeField] private float flyDuration = 10f;
        [SerializeField] private float altitudeValue = 3f;

        public override void InstallBindings()
        {
            Container.Bind<IEnumerable<ICoinEffect>>()
                .FromInstance(new[] { new SlowDownEffect(flyDuration, altitudeValue) });
        }
    }
}
