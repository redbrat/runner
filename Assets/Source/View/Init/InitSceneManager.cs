using Source.View.Init.ScenesManagement;
using UnityEngine;
using Zenject;

namespace Source.View.Init
{
    public class InitSceneManager : MonoBehaviour
    {
        [Inject] private readonly ScenesManager scenesManager;
        private void Start()
        {
            scenesManager.LoadMenuScene();
        }
    }
}
