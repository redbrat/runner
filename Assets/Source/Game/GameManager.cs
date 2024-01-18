using System;
using JetBrains.Annotations;

namespace Source.Game
{
    [UsedImplicitly]
    public class GameManager
    {
        public bool GameIsFinished { get; private set; }
        public event Action GameFinished;

        public void FinishTheGame()
        {
            GameIsFinished = true;
            GameFinished?.Invoke();
        }
    }
}
