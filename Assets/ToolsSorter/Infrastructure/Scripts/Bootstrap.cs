using UnityEngine;
using Zenject;

namespace ToolsSorter.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private Level _level;
        private void Awake()
        {
            DontDestroyOnLoad(this);

            var game = new Game();
            game.Start();
        } 
    }
}