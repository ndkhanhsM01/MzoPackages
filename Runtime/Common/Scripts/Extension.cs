using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Mzo
{
    public static class Extension
    {
        public static void Show(this Component component)
        {
            if (component != null)
                component.gameObject.SetActive(true);
        }
        public static void Hide(this Component component)
        {
            if (component != null)
                component.gameObject.SetActive(false);
        }
        public static void Show(this GameObject component)
        {
            if (component != null)
                component.SetActive(true);
        }
        public static void Hide(this GameObject component)
        {
            if (component != null)
                component.SetActive(false);
        }
        public static Coroutine DelayedCallback(this MonoBehaviour monoBehaviour, float delay, Action callback)
        {
            return monoBehaviour.StartCoroutine(DelayedCallbackCoroutine(delay, callback));
        }

        private static IEnumerator DelayedCallbackCoroutine(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        public static void DebugTag(this MonoBehaviour gameObj)
        {
            if (gameObj != null)
            {
                Debug.Log($"[{gameObj.name}] has tag: \"{gameObj.tag}\"");
            }
        }

        public static void AddListener(this UnityEngine.UI.Button button, UnityEngine.Events.UnityAction callback)
        {
            if (button != null)
            {
                button.onClick.AddListener(callback);
            }
        }

        public static List<T> SpawnObjectsInto<T>(this Transform parent, T prefab, int amount) where T : MonoBehaviour
        {
            List<T> result = new List<T>();
            for (int i = 0; i < amount; i++)
            {
                T clone = UnityEngine.Object.Instantiate(prefab, parent);
                result.Add(clone);
            }

            return result;
        }
    }
}
