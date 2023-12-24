using System;
using System.Collections;
using ToolsSorter.Service;
using ToolsSorter.Service.CollideService;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Wheel
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class Wheel : MonoBehaviour, IAttaching, ICircle
    {
        [SerializeField] private float _speed;

        [Inject] private readonly CollideController _collideController;

        private CapsuleCollider _capsuleCollider;
        private Coroutine _stopRotateCoroutine;
        private WaitForFixedUpdate _waitForFixedUpdate;

        public Transform Transform { get; private set; }

        private void Awake()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _waitForFixedUpdate = new WaitForFixedUpdate();
            Transform = transform;
        }

        private void OnEnable() => 
            _collideController.Losed += OnLosed;

        private void OnDisable() => 
            _collideController.Losed -= OnLosed;

        private void Update() => 
            Transform.Rotate(_speed * Time.deltaTime * Vector3.up);

        public float GetLength() =>
            2 * Mathf.PI * _capsuleCollider.radius;

        private void OnLosed()
        {
            if (_stopRotateCoroutine is not null)
                StopCoroutine(_stopRotateCoroutine);

            _stopRotateCoroutine = StartCoroutine(StopRotateRoutine());
        }

        private IEnumerator StopRotateRoutine()
        {
            float slowdownSpeed = _speed / _collideController.SlowdownSeconds * Time.fixedDeltaTime;

            while (_speed > 0)
            {
                _speed -= slowdownSpeed;

                yield return _waitForFixedUpdate;
            }

            _speed = 0;
        }
    }
}
