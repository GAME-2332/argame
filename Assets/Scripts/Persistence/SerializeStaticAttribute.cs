using System;
using UnityEngine;

namespace Persistence {
    /// <summary>
    /// Add this attribute to a static instance field to serialize it. The field type must also extend <see cref="IRuntimeSerialized"/>.
    /// </summary>
    public class SerializeStaticAttribute : PropertyAttribute {
        public readonly string Name;
        
        public SerializeStaticAttribute(string name) {
            Name = name;
        }
    }
}