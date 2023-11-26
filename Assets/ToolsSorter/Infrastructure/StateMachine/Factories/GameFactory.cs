using Infrastructure.StateMachine.States;
using Infrastructure.StateMachine.Transitions;

namespace Infrastructure.StateMachine.Factory
{
    internal class GameFactory
    {
        internal Game Create()
        {
            var bootstrapState = new BootstrapState(); 
            var menuState = new MenuState(); 
            var gameplayState = new GamePlayState(); 

            var transitionToMenu = new TransitionToMenu(menuState);
            var transitionToGamePlay = new TransitionToGameplay(gameplayState);

            bootstrapState.Init(transitionToMenu);
            menuState.Init(transitionToGamePlay);
            gameplayState.Init(transitionToMenu);

            return new Game(bootstrapState);
        }
    }
}