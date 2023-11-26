using System;
using UnityEngine;

namespace Views.Game.InteractableObjects
{
    public class Spawner : MonoBehaviour
    {
        private Item[] _items;

        public void Init(params Item[] items) => 
            _items = items ?? throw new ArgumentNullException(nameof(items));

        public Item Create()
        {
            if (_items is null)
                throw new NullReferenceException(nameof(_items));

            if (_items.Length <= 0)
                throw new InvalidOperationException();

            var item = Instantiate(_items[0]);

            return item;
        }
    }
}
