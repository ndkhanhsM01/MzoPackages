using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mzo.LocalDataSystem
{
    /// <summary>
    /// Attach <DemoLoadDataLocal> component into empty object to test
    /// </summary>
    public class DemoLoadDataLocal : MonoBehaviour
    {
        public DemoData player;
        private void Start()
        {
            DemoDataSystem.SetFileName("MyData");
            DemoDataSystem.Load();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DemoLoadDataLocal))]
    public class DemoLoadDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DemoLoadDataLocal demo = (DemoLoadDataLocal)target;

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save"))
            {
                DemoDataSystem.Data = demo.player;
                DemoDataSystem.Save();
            }

            if (GUILayout.Button("Load"))
            {
                DemoDataSystem.Load(() =>
                {
                    demo.player = DemoDataSystem.Data;
                });
            }
            GUILayout.EndHorizontal();
        }
    }
#endif
}

