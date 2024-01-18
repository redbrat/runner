using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Source.View.Game.Coins.Effects
{
    public class SlowDownCoinInstaller : MonoInstaller
    {
        [SerializeField] private float slowDownDuration = 5f;
        [SerializeField] private float slowDownValue = 1f;
        
        public override void InstallBindings()
        {
            Container.Bind<IEnumerable<ICoinEffect>>()
                .FromInstance(new[] { new SlowDownEffect(slowDownDuration, slowDownValue) });
        }
    }
}
