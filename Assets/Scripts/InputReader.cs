using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class InputReader : MonoBehaviour
    {
        public event UnityAction<Vector2> Taped;

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                Taped?.Invoke(Input.mousePosition);
            }
#else
            if (Input.touchCount > 0)
            {
                Taped?.Invoke(Input.touches[0].position);
            }
#endif
        }
    }
}
