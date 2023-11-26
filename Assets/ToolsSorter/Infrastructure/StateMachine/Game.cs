using Infrastructure.StateMachine.States;
using System;

namespace Infrastructure.StateMachine
{
    internal class Game
    {
        private readonly State _firstState;
        private State _currentState;

        public Game(State state) => 
            _firstState = state ?? throw new ArgumentNullException(nameof(state));

        public void Start()
        {
            if (_currentState is not null)
                throw new InvalidOperationException($"{nameof(GetType)} is already running");

            Transit(_firstState);
        }

        public void Reset()
        {
            if (_currentState is null)
                throw new InvalidOperationException($"Cannot reset because the {nameof(GetType)} is not running.");

            Transit(_firstState);
        }

        public void Update()
        {
            if (_currentState is null)
                throw new InvalidOperationException($"Cannot update because the {nameof(GetType)} is not running.");

            State nextState = _currentState.GetNextState();

            Transit(nextState);
        }

        private void Transit(State state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));

            _currentState?.Stop();
            _currentState = state;
            _currentState?.Start();
        }
    }
}