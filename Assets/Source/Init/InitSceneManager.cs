using Source.Init.ScenesManagement;
using UnityEngine;
using Zenject;

namespace Source.Init
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
