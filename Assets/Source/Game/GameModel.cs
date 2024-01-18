using System;
using JetBrains.Annotations;

namespace Source.Game
{
    [UsedImplicitly]
    public class GameModel
    {
        public event Action<int> ScoreChanged; 
        public int Score { get; private set; }

        public void Add1Score()
        {
            Score += 1;
            ScoreChanged?.Invoke(Score);
        }
    }
}
