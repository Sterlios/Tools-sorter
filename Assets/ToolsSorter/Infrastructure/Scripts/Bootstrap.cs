using Infrastructure.StateMachine.Factory;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);

            var gameFactory = new GameFactory();
            var game = gameFactory.Create();
            
        }
    }
}
