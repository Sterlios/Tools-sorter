using UnityEngine;

namespace ToolsSorter.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);

            var game = new Game();
            game.Start();
        } 
    }
}