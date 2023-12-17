using System;
using UnityEngine;

namespace ToolsSorter.Service.CollideService
{
    public interface ICollided
    {
        event Action<ICollided, Collision> Collided;

        void Attach(IAttaching attaching);
        void Destroy();
    }
}
