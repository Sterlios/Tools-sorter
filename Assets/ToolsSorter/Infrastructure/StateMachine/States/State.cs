using Infrastructure.StateMachine.Transitions;
using System;

namespace Infrastructure.StateMachine.States
{
    internal abstract class State
    {
        private Transition[] _transitions;

        internal void Init(params Transition[] transitions) =>
            _transitions = transitions ?? throw new ArgumentNullException(nameof(transitions));

        internal void Start()
        {
            if(_transitions is null)
                throw new NullReferenceException(nameof(_transitions));

            foreach (var transition in _transitions)
                transition.Enable();
        }

        internal void Stop()
        {
            if (_transitions is null)
                throw new NullReferenceException(nameof(_transitions));

            foreach (var transition in _transitions)
                transition.Disable();
        }

        internal State GetNextState()
        {
            if (_transitions is null)
                throw new NullReferenceException(nameof(_transitions));

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