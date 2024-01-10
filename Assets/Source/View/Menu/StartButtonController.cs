using Source.View.Init.ScenesManagement;
using UnityEngine;
using Zenject;

namespace Source.View.Menu
{
    public class StartButtonController : MonoBehaviour
    {
        [Inject] private readonly ScenesManager scenesManager;
        
        public void OnClick()
        {
            scenesManager.UnloadMenuScene();
            scenesManager.LoadGameScene();
        }
    }
}
