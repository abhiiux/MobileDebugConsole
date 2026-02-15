using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MobileDebugger
{
    public static class MobileDebugSetupTool
    {
        private const string PrefabPath =
        "Packages/com.mobileconsole.unitypackage/MobileDebugSolution/Runtime/Prefabs/Mobile Debug Console.prefab";

        // Testing path
        private const string prefabPath =
        "Assets/MobileDebugConsole copy/MobileDebugSolution/Runtime/Prefabs/Mobile Debug Console.prefab";
        // 

        [MenuItem("Tools/Mobile Debug Console/ Setup In Scene")]
        public static void Setup()
        {
            Debug.Log("Mobile Debug Setup Running");
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath);
            if (prefab == null)
            {
                Debug.LogError($"Prefab not found at: {PrefabPath}");
                return;
            }

            Canvas canvas = GetOrCreateCanvas();
            PrefabUtility.InstantiatePrefab(prefab,canvas.transform);
        }

        private static Canvas GetOrCreateCanvas()
        {
            var canvas = Object.FindFirstObjectByType<Canvas>();
            if (canvas != null) return canvas;

            var go = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvas = go.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            return canvas;
        }
    }
}