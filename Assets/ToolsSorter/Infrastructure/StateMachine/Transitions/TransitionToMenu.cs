using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine.Transitions
{
    internal class TransitionToMenu : Transition
    {
        public TransitionToMenu(MenuState state) : base(state)
        {
        }
    }
}