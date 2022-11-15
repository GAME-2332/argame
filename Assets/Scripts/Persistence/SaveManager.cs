using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Util;

namespace Persistence {
    public class SaveManager {
        public static string Path() {
            return Application.persistentDataPath + "/save_data";
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
            list.AddRange(CollectExternals());
            return list;
        }

        private static IEnumerable<IRuntimeSerialized> CollectExternals() {
            return
                from field in Reflection.GetStaticFieldsWithAttribute<IRuntimeSerialized>(typeof(SerializeStaticAttribute))
                select field.Value;
        }
    }
}