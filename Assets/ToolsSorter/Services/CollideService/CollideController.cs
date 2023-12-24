using System;
using ToolsSorter.Service.ThrowService;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Service.CollideService
{
    public class CollideController : IDisposable
    {
        [Inject] private readonly Thrower _thrower;

        public float SlowdownSeconds { get; } = 2;

        public event Action Losed;

        public CollideController(Thrower thrower)
        {
            _thrower = thrower ?? throw new ArgumentNullException(nameof(thrower));
            _thrower.Thrown += OnThrown;
        }

        private void OnThrown(IThrown thrown)
        {
            if (thrown is null)
                throw new ArgumentNullException(nameof(thrown));

            if (thrown is ICollided collided)
                collided.Collided += OnCollided;
        }

        private void OnCollided(ICollided collided, Collision collision)
        {
            collided.Collided -= OnCollided;

            if (collision.gameObject.TryGetComponent(out ICollided other))
                Collide(collided, other);
            else if (collision.gameObject.TryGetComponent(out IAttaching attaching))
                Collide(collided, attaching);
        }

        private void Collide(ICollided collided, IAttaching attaching) => 
            collided.Attach(attaching);

        private void Collide(ICollided collided, ICollided other)
        {
            collided.Destroy();
            other.Destroy();

            Losed?.Invoke();
        }

        public void Dispose() =>
            _thrower.Thrown -= OnThrown;
    }
}
