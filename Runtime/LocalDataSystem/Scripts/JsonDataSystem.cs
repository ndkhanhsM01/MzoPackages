using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace Mzo.LocalDataSystem
{
    public abstract class JsonDataSystem<T> where T : JsonDataSaving
    {
        public static T Data;
        public static string fileNameDefault => Data.GetType().Name.ToString();

        public static void SetFileName(string name)
        {
            fileName = name;
        }
        public static string fileName { get; private set; }
        public static void Load(Action onLoadComplete = null)
        {
            // load file
            string path = Application.persistentDataPath + "/" + fileName;
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Data = JsonUtility.FromJson<T>(content);
                Debug.LogWarning($"Read data from file: {path}");
            }
            else
            {
                Debug.LogWarning($"Not exist file: {path}");
                Data = default;
            }

            onLoadComplete?.Invoke();
        }
        public static void Save()
        {
            string path = Application.persistentDataPath + "/" + fileName;
            string jsonData = JsonConvert.SerializeObject(Data ?? default, Formatting.Indented);

            File.WriteAllText(path, jsonData);

            Debug.LogWarning($"<{typeof(T)}> data saved into: {path}");
        }
    }
}