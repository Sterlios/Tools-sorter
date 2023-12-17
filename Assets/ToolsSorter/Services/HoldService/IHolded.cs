using UnityEngine;

namespace ToolsSorter.Service.HoldService
{
    public interface IHolded
    {
        void Activate();
        void Deactivate();
        void SetParent(Transform transform);
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}
