using System;
using System.Collections;
using UnityEngine;

namespace ToolsSorter.Items
{
    internal class Movement
    {
        private readonly float _speed;
        private readonly Rigidbody _rigidbody;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly WaitForFixedUpdate _waitForFixedUpdate;
        private readonly Transform _transform;
        private Coroutine _moveCoroutine;

        public Movement(float speed, Rigidbody rigidbody, Transform transform, ICoroutineRunner coroutineRunner)
        {
            if(speed <= 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            _speed = speed;
            _transform = transform != null ? transform : throw new ArgumentNullException(nameof(transform));
            _rigidbody = rigidbody != null ? rigidbody : throw new ArgumentNullException(nameof(rigidbody));
            _coroutineRunner = coroutineRunner ?? throw new ArgumentNullException(nameof(coroutineRunner));
            _waitForFixedUpdate = new WaitForFixedUpdate();
        }

        public void MoveForward()
        {
            Stop();

            _moveCoroutine = _coroutineRunner.StartCoroutine(Go());
        }

        public void MoveTo(Vector3 to)
        {
            Stop();

            _moveCoroutine = _coroutineRunner.StartCoroutine(GoTo(to));
        }

        public void Stop()
        {
            if (_moveCoroutine is not null)
                _coroutineRunner.StopCoroutine(_moveCoroutine);
        }

        private IEnumerator Go()
        {
            bool isWorking = true;

            while (isWorking)
            {
                _rigidbody.AddForce(_speed * Time.fixedDeltaTime * _transform.forward, ForceMode.Impulse);

                yield return _waitForFixedUpdate;
            }
        }

        private IEnumerator GoTo(Vector3 to)
        {
            while (_rigidbody.position != to)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, to, _speed / 4 * Time.fixedDeltaTime);

                yield return _waitForFixedUpdate;
            }
        }
    }
}