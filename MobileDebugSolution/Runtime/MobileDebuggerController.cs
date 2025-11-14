using UnityEngine;

namespace MobileDebugger
{
    public class MobileDebuggerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject debugConsole;
        [SerializeField]
        private RectTransform startButton;
        [SerializeField]
        private RectTransform closeButton;
        private RectTransform mine;
        private void Start() {
            // Debug.Log("hi");
            mine = GetComponent<RectTransform>();

            mine.anchoredPosition = new Vector2(0f, AdjustComponent(mine));
           startButton.sizeDelta = new Vector2(200f,200f);
           closeButton.sizeDelta = new Vector2(200f,200f);
        }

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
        private float AdjustComponent(RectTransform rt)
        {
            mine.anchorMin = new Vector2(0f, 0f);
            mine.anchorMax = new Vector2(1f, 0f);
            mine.pivot = new Vector2(0.5f, 0.5f);
            float height = mine.rect.height;
            height /= 2f;

            return height;
        }
    }
}
