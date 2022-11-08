using UnityEngine;

namespace XR {
    [RequireComponent(typeof(Collider), typeof(Renderer), typeof(Outline))]
    public abstract class Interaction : MonoBehaviour {
        private Outline _outline;
        private bool _outlineEnabled;

        private void Start() {
            _outline = GetComponent<Outline>();
        }

        private void Update() {
            if (_outline.enabled != _outlineEnabled) _outline.enabled = _outlineEnabled;
        }

        public void SetOutline(bool value) {
            _outline.enabled = _outlineEnabled = value;
        }

        public abstract void Interact();
    }
}