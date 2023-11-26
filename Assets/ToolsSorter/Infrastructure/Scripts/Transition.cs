using System;

namespace Infrastructure
{
    internal abstract class Transition
    {
        private readonly State _state;
        private bool _isEnable;
        private bool _isOpen;

        protected Transition(State state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _isEnable = false;
            _isOpen = false;
        }

        internal State State =>
            _isEnable && _isOpen ? _state : null;

        internal void Enable() => 
            _isEnable = true;

        internal void Disable()
        {
            Close();
            _isEnable = false;
        }

        internal void Open() =>
            _isOpen = true;

        private void Close() => 
            _isOpen = false;
    }
}