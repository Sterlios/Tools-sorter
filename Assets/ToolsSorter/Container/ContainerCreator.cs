using System.Collections.Generic;
using ToolsSorter.Items;
using ToolsSorter.Service;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Container
{
    public class ContainerCreator 
    {
        [Inject] private readonly ItemContainer _container;
        [Inject] private readonly ICircle _circle;

        [Inject] private readonly Item _itemTemplate;

        public ContainerCreator(ItemContainer container, ICircle circle, Item itemTemplate)
        {
            _container = container ?? throw new System.ArgumentNullException(nameof(container));
            _circle = circle ?? throw new System.ArgumentNullException(nameof(circle));
            _itemTemplate = itemTemplate ?? throw new System.ArgumentNullException(nameof(itemTemplate));
        }

        public void CreateList()
        {
            List<Item> items = new List<Item>();

            float circleLength = _circle.GetLength();
            float itemWidth = _itemTemplate.Width;
            int maxItemCount = (int)(circleLength / itemWidth);

            for(int i = 0; i < maxItemCount; i++)
            {
                Item item = Object.Instantiate(_itemTemplate, _container.transform);
                items.Add(item);
            }

            _container.Init(items);
        }
    }
}
