using Source.View.Init.ScenesManagement;
using Zenject;

namespace Source.View.Init
{
    public class InitSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScenesManager>().AsSingle();
        }
    }
}
