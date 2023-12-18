using ToolsSorter.Service.CollideService;
using UnityEngine;

namespace ToolsSorter.Wheel
{
    public class Wheel : MonoBehaviour, IAttaching
    {
        [SerializeField] private float _speed;

        public Transform Transform { get; private set; }

        private void Awake() => 
            Transform = transform;

        private void Update() => 
            Transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.up);
    }
}
