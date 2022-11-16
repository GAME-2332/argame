using UnityEngine;
using Util;

namespace XR {
    [RequireComponent(typeof(Collider), typeof(Renderer), typeof(Outline))]
    public abstract class Interaction : MonoBehaviour {
        private Outline _outline;
        private bool _outlineEnabled;

        private void Update() {
            if (_outline == null) _outline = GetComponent<Outline>();
            if (_outline.enabled != _outlineEnabled) _outline.enabled = _outlineEnabled;
        }

        public void SetOutline(bool value) {
            _outlineEnabled = value;
        }

        public abstract void Interact();
    }
}