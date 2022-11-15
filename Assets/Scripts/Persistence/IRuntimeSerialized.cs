using UnityEngine;

namespace Persistence {
    public interface IRuntimeSerialized : ISerializationCallbackReceiver {
        public string GetSerializedName();
        
        void OnBeforeSerialize() { }

        void OnAfterDeserialize() { }
    }
}