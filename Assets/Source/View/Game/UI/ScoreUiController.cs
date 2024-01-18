using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Source.View.Game.UI
{
    public class ScoreUiController : MonoBehaviour
    {
        [Inject] private readonly GameModel gameModel;
        [SerializeField] private TextMeshProUGUI text;

        private void OnEnable()
        {
            OnScoreChanged(gameModel.Score);
            gameModel.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            gameModel.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            text.text = newScore.ToString();
        }
    }
}
