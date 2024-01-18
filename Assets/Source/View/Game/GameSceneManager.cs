using UnityEngine;
using Zenject;

namespace Source.View.Game
{
    public class GameSceneManager : MonoBehaviour
    {
        [Inject] private readonly IFactory<int, Track> trackFactory;
        
        private void Start()
        {
            var track = trackFactory.Create(100);
            track.ShowSections(0, 10);
        }
    }
}
