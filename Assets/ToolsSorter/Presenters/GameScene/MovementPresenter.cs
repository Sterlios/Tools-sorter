using Presenters.Interfaces;
using UnityEngine;
using Zenject;

namespace Presenters.Scene
{
    public class MovementPresenter
    {
        [Inject] private readonly IMovementView _movementView;

        private void Move()
        {
            _movementView.Position = new Vector3(2,2,2);
        }
    }
}
