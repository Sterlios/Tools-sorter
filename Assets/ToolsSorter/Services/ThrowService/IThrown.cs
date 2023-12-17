using UnityEngine;

namespace ToolsSorter.Service.ThrowService
{
    public interface IThrown
    {
        void Prepare(Transform transform);
        void Throw();
    }
}
