
using Mzo.LocalDataSystem;

namespace Mzo.LocalDataSystem
{
    public class DemoDataSystem : JsonDataSystem<DemoData>
    {
    }

    [System.Serializable]
    public class DemoData : JsonDataSaving
    {
        public string name;
        public string description;
    }
}