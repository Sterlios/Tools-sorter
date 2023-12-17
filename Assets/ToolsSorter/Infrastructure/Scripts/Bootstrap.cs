using UnityEngine;

namespace ToolsSorter.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);

            Game game = new Game();
            game.Start();
        } 
    }
}