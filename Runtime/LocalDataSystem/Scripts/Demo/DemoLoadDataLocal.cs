using UnityEngine;
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
}

