using Presenters.Interfaces;
using Presenters.Scene;
using UnityEngine;
using Zenject;

namespace Views
{
    public class Movement : MonoBehaviour, IMovementView
    {
        [Inject]
        private readonly MovementPresenter _presenter;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
