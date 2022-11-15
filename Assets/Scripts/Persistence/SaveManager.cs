using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Persistence {
    public class SaveManager {
        private static readonly List<IRuntimeSerialized> _externals = new();
        
        public static string Path() {
            return Application.persistentDataPath + "/save_data";
        }
        
        /// <summary>
        /// Registers a non-monobehaviour object to be serialized. Call in your static initializer.
        /// </summary>
        public static void RegisterSerializedExternal(IRuntimeSerialized obj) {
            _externals.Add(obj);
        }

        public static void SerializeAll() {
            if (!Directory.Exists(Path())) Directory.CreateDirectory(Path());
            
            foreach (IRuntimeSerialized obj in Collect()) {
                string path = Path() + "/" + obj.GetSerializedName() + ".dat";
                File.WriteAllText(path, JsonUtility.ToJson(obj));
            }
        }
        
        public static void DeserializeAll() {
            if (!Directory.Exists(Path())) Directory.CreateDirectory(Path());
            
            foreach (IRuntimeSerialized obj in Collect()) {
                string path = Path() + "/" + obj.GetSerializedName() + ".dat";
                if (File.Exists(path)) {
                    JsonUtility.FromJsonOverwrite(File.ReadAllText(path), obj);
                }
            }
        }
        
        private static List<IRuntimeSerialized> Collect() {
            var list = new List<IRuntimeSerialized>();
            var objects = GameObject.FindObjectsOfType<MonoBehaviour>();
            foreach (var obj in objects) {
                if (obj is IRuntimeSerialized) {
                    list.Add(obj as IRuntimeSerialized);
                }
            }

            list.AddRange(_externals);
            return list;
        }
    }
}