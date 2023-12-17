using System.Collections.Generic;
using ToolsSorter.Items;
using ToolsSorter.Service.HoldService;
using UnityEngine;

namespace ToolsSorter.Container
{
    public class ItemContainer : MonoBehaviour, IContainer
    {
        [SerializeField] private Item _itemTemplate;
        [SerializeField] private int _count;

        private List<Item> _items;

        private void Awake()
        {
            _items = new List<Item>();

            for (int i = 0; i < _count; i++)
            {
                Item item = Instantiate(_itemTemplate, transform);
                item.Deactivate();
                _items.Add(item);
            }
        }

        public bool TryGetItem(out IHolded item)
        {
            item = null;

            if (_items.Count > 0)
            {
                item = _items[0];
                _items.RemoveAt(0);
                return true;
            }

            return false;
        }
    }
}
