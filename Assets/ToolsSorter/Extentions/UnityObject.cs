using UnityEngine;

namespace ToolsSorter.UnityObjects
{
    public static class UnityObject
    {
        public static void Activate(this GameObject gameObject) =>
            gameObject.SetActive(true);

        public static void Deactivate(this GameObject gameObject) =>
            gameObject.SetActive(false);
    }
}