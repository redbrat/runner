using Zenject;

namespace Source.View.Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerBehaviourContext>().AsSingle();
        }
    }
}
