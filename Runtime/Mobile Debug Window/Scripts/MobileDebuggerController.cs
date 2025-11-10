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

    }
}
