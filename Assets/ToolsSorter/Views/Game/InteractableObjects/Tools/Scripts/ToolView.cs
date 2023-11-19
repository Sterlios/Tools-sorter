using Presenters;
using Presenters.Interfaces;
using UnityEngine;
using Zenject;

namespace Views.Game.InteractableObjects.Tools
{
    public class ToolView : MonoBehaviour, IMovementView
    {
        private MovementPresenter _movementPresenter;

        public void Init(MovementPresenterFactory movementPresenterFactory)
        {
            _movementPresenter = movementPresenterFactory.Create(this);
        }
    }
}
