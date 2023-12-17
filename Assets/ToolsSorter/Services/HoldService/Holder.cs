using System;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Service.HoldService
{
    public class Holder : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        [Inject] private readonly IContainer _container;

        private IHolded _holded;
        private Transform _transform;

        public event Action Completed;
        public event Action<IHolded> Gotten;

        private void Awake() => 
            _transform = transform;

        private void Start() => 
            TakeNextItem();

        public void TakeNextItem()
        {
            if(_container.TryGetItem(out _holded) == false)
            {
                Completed?.Invoke();
                return;
            }

            _holded.Activate();
            _holded.SetParent(_transform);
            _holded.SetPosition(_spawnPoint.position);
            _holded.SetRotation(_spawnPoint.rotation);

            Gotten?.Invoke(_holded);
        }        
    }
}
