using UnityEngine;

namespace Persistence {
    /// <summary>
    /// If on a MonoBehavior object, this object will be saved and loaded automatically upon scene switching. If you're
    /// using an external object that doesn't exist within a scene, use the [SerializeStatic] attribute instead.
    /// </summary>
    public interface IRuntimeSerialized {
        public string GetSerializedName();
    }
}