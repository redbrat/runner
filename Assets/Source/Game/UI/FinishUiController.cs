using Source.Init.ScenesManagement;
using TMPro;
using UnityEngine;
using Zenject;

namespace Source.Game.UI
{
    public class FinishUiController : MonoBehaviour
    {
        [Inject] private readonly GameModel gameModel;
        [Inject] private readonly ScenesManager scenesManager;
        [Inject] private readonly GameManager gameManager;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject visuals;

        private void OnEnable()
        {
            gameManager.GameFinished += OnGameFinished;
        }

        private void OnDisable()
        {
            gameManager.GameFinished -= OnGameFinished;
        }

        private void OnGameFinished()
        {
            scoreText.text = $"Your score: {gameModel.Score}";
            visuals.SetActive(true);
        }

        public void OnExitClick()
        {
            scenesManager.UnloadGameScene();
            scenesManager.LoadMenuScene();
        }
    }
}
