using System;
using ToolsSorter.Service.HoldService;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Service.ThrowService
{
    public class Thrower : MonoBehaviour
    {
        [SerializeField] private Transform _throwingPoint;

        [Inject] private readonly Holder _holder;

        private IThrown _thrown;

        public event Action<IThrown> Thrown;

        private void OnEnable() =>
            _holder.Gotten += OnGotten;

        private void OnDisable() =>
            _holder.Gotten -= OnGotten;

        public void Throw()
        {
            if (_thrown == null)
                throw new InvalidOperationException(nameof(_thrown));

            _thrown.Throw();

            Thrown?.Invoke(_thrown);

            _holder.TakeNextItem();
        }

        private void OnGotten(IHolded holded)
        {
            if (holded is null)
                throw new ArgumentNullException(nameof(holded));

            if (holded is not IThrown thrown)
                return;

            _thrown = thrown;
            _thrown.Prepare(_throwingPoint);
        }
    }
}
