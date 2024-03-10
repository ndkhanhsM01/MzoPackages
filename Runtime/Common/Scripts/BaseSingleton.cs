using UnityEngine;

namespace Mzo
{
    public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected virtual void Awake()
        {
            if(Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Debug.LogWarning($"Already exist one Instance of {typeof(T)}, so removed this");
                Destroy(this.gameObject);
            }
        }
    }
}