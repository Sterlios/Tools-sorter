using System;
using System.Collections;
using UnityEngine;

namespace Views
{
    public class Item : MonoBehaviour
    {
        [SerializeField, Range(0.001f, 10f)] private float _speed;
        private Transform _transform;
        private Coroutine _moveCoroutine;

        private void Awake() =>
            _transform = transform;

        public void Move(Vector3 direction)
        {
            if(direction == Vector3.zero)
                throw new ArgumentNullException(nameof(direction));

            if (_moveCoroutine is not null)
                StopCoroutine(_moveCoroutine);

            _moveCoroutine = StartCoroutine(Transfer(direction));
        }

        public void Stop()
        {
            if (_moveCoroutine is not null)
                StopCoroutine(_moveCoroutine);
        }

        private IEnumerator Transfer(Vector3 direction)
        {
            Vector3 normilize = Vector3.Normalize(direction);

            while (_transform.position != direction)
            {
                _transform.position += normilize * (_speed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
