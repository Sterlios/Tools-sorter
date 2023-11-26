using System;

namespace Infrastructure
{
    internal abstract class State
    {
        private readonly Transition[] _transitions;

        protected State(Transition[] transitions) =>
            _transitions = transitions ?? throw new ArgumentNullException(nameof(transitions));

        internal void Start()
        {
            foreach (var transition in _transitions)
                transition.Enable();
        }

        internal void Stop()
        {
            foreach (var transition in _transitions)
                transition.Disable();
        }

        internal State GetNextState()
        {
            foreach (var transition in _transitions)
            {
                State nextState = transition.State;

                if (nextState != null)
                    return nextState;
            }

            return null;
        }
    }
}