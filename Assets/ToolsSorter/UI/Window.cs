using System.Collections;
using ToolsSorter.UnityObjects;
using UnityEngine;

namespace ToolsSorter.UI
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private RectTransform _child;

        private WaitForFixedUpdate _waitForFixedUpdate;
        private Coroutine _delayCoroutine;

        private void Awake() => 
            _waitForFixedUpdate = new WaitForFixedUpdate();

        public void Activate(float delay)
        {
            gameObject.Activate();

            if (_delayCoroutine is not null)
                StopCoroutine(_delayCoroutine);

            _delayCoroutine = StartCoroutine(ActivateAfterDelay(delay));
        }

        private IEnumerator ActivateAfterDelay(float delay)
        {
            float timer = 0;

            while (timer < delay)
            {
                timer += Time.fixedDeltaTime;

                yield return _waitForFixedUpdate;
            }

            _child.gameObject.Activate();
        }
    }
}
