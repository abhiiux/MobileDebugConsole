using UnityEngine;

namespace MobileDebugger
{
    public class MobileDebuggerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject debugConsole;

        public void DebugWindowButton()
        {
            if (debugConsole == null) Debug.Log(" console is null");
            
            bool state = !debugConsole.activeInHierarchy;

            ToggleDebugWindow(state);
        }

        private void ToggleDebugWindow(bool _state)
        {
            debugConsole.SetActive(_state);
        }
        private void ApplyStretch(Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax, RectTransform rt)
        {
            if (rt == null) return;

            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = offsetMin;
            rt.offsetMax = offsetMax;
        }
        private void ApplyFullScreenStretch()
        {
            ApplyStretch( Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero, transform as RectTransform);
        }
        private void ApplyBottomStretch()
        {
            RectTransform rt = transform.Find("DEBUG_CONSOLE")?.GetComponent<RectTransform>();
            ApplyStretch(Vector2.zero , new Vector2(1f, 0f),Vector2.zero, new Vector2(0f,rt.rect.height), rt);
        } 

#if UNITY_EDITOR
        public void OnValidate()
        {
            ApplyFullScreenStretch();
            ApplyBottomStretch();
        }
#endif
    }
}
