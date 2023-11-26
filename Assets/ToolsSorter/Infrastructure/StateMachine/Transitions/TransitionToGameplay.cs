using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine.Transitions
{
    internal class TransitionToGameplay : Transition
    {
        public TransitionToGameplay(GamePlayState state) : base(state)
        {
        }
    }
}