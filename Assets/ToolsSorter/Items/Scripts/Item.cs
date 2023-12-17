using System;
using ToolsSorter.Service.CollideService;
using ToolsSorter.Service.HoldService;
using ToolsSorter.Service.ThrowService;
using ToolsSorter.UnityObjects;
using UnityEngine;

namespace ToolsSorter.Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour, ICoroutineRunner, ICollided, IThrown, IHolded
    {
        [SerializeField] private float _speed;

        private Transform _transform;
        private Movement _movement;

        public event Action<ICollided, Collision> Collided;

        private void Awake()
        {
            _transform = transform;
            _movement = new Movement(_speed, GetComponent<Rigidbody>(), _transform, this);
        }

        private void OnCollisionEnter(Collision other)=>
            Collided?.Invoke(this, other);

        public void Prepare(Transform transform)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            _movement.MoveTo(transform.position);
        }

        public void Throw()
        {
            SetParent(null);
            _movement.MoveForward();
        }

        public void Stop() =>
            _movement.Stop();

        public void SetParent(Transform transform) => 
            _transform.SetParent(transform);

        public void SetPosition(Vector3 position) =>
            _transform.position = position;

        public void SetRotation(Quaternion rotation) =>
            _transform.rotation = rotation;

        public void Attach(IAttaching attaching)
        {
            Stop();
            SetParent(attaching.Transform);
        }

        public void Destroy() =>
            Destroy(gameObject);

        public void Activate() =>
            gameObject.Activate();

        public void Deactivate() =>
            gameObject.Deactivate();
    }
}
