using Presenters.Interfaces;

namespace Presenters
{
    public class MovementPresenter
    {
        private readonly IMovementView _view;

        public MovementPresenter(IMovementView view)
        {
            _view = view ?? throw new System.ArgumentNullException(nameof(view));
        }
    }
}
