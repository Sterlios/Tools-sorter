using Presenters.Interfaces;

namespace Presenters
{
    public class MovementPresenterFactory
    {
        public MovementPresenter Create(IMovementView view) => 
            new MovementPresenter(view);
    }
}
