using System.Collections;
using ToolsSorter.Service.CollideService;
using UnityEngine;

namespace ToolsSorter.Wheel
{
    public class Wheel : MonoBehaviour, IAttaching
    {
        [SerializeField] private float _speed;

        private Coroutine _rotateCoroutine;
        private WaitForFixedUpdate _waitForFixedUpdate;

        public Transform Transform { get; private set; }

        private void Awake()
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();
            Transform = transform;
        }

        private void OnEnable()
        {
            StopRotate();

            _rotateCoroutine = StartCoroutine(Rotate());
        }

        private void OnDisable() => 
            StopRotate();

        private void StopRotate()
        {
            if (_rotateCoroutine is not null)
                StopCoroutine(_rotateCoroutine);
        }

        private IEnumerator Rotate()
        {
            while (true)
            {
                Transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.up);

                yield return _waitForFixedUpdate;
            }
        }
    }
}
