using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace Source.Init.ScenesManagement
{
    [UsedImplicitly]
    public class ScenesManager
    {
        public void LoadMenuScene()
        {
            SceneManager.LoadScene(Scenes.MENU, LoadSceneMode.Additive);
        }
        
        public void LoadGameScene()
        {
            SceneManager.LoadScene(Scenes.GAME, LoadSceneMode.Additive);
        }
        
        public void UnloadMenuScene()
        {
            SceneManager.UnloadSceneAsync(Scenes.MENU);
        }

        public void UnloadGameScene()
        {
            SceneManager.UnloadSceneAsync(Scenes.GAME);
        }
    }
}
