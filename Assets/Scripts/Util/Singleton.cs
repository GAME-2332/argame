using System;
using UnityEngine;

namespace Util {
    /// <summary>
    /// Holds a single nullable instance of an object, clearing when necessary and calling a given mehtod
    /// upon set/get. Just useful because I do this a lot anyway with member fields, this is easier.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Singleton<T> {
        public T Value {
            get => value;
            set {
                if (this.value != null && _onUnset != null) _onUnset.Invoke(this.value);
                this.value = value;
                if (this.value != null) _onSet.Invoke(this.value);
            }
        }
        [SerializeField] private T value;
        private Action<T> _onSet;
        private Action<T> _onUnset;

        /// <param name="initial">An initial value</param>
        /// <param name="onSet">The function to call on a given value when it's set</param>
        /// <param name="onUnset">The function to call on a given value when it becomes no longer the selected instance</param>
        public Singleton(T initial, Action<T> onSet, Action<T> onUnset) {
            value = initial;
            _onSet = onSet;
            _onUnset = onUnset;
        }
    }
}