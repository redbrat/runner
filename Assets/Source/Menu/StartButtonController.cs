using Source.Init.ScenesManagement;
using UnityEngine;
using Zenject;

namespace Source.Menu
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
