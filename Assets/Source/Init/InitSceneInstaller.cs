using Source.Init.ScenesManagement;
using Zenject;

namespace Source.Init
{
    public class InitSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScenesManager>().AsSingle();
        }
    }
}
