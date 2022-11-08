using UnityEngine;
using UnityEngine.Internal;

namespace XR {
    [RequireComponent(typeof(Collider), typeof(Renderer))]
    public abstract class Interaction : MonoBehaviour {
        public Outline.Mode outlineMode = Outline.Mode.OutlineAndSilhouette;
        public Color outlineColor = Color.yellow;
        public float outlineWidth = 8f;
        
        private Outline _outline;
        private bool _outlineEnabled;

        private void Awake() {
            _outline = gameObject.AddComponent<Outline>();
        }

        private void Update() {
            if (!_outlineEnabled) _outline.enabled = false;
        }

        public void SetOutline(bool value) {
            if (value) {
                _outline.OutlineMode = outlineMode;
                _outline.OutlineColor = outlineColor;
                _outline.OutlineWidth = outlineWidth;
            }
            _outline.enabled = value;
        }

        public abstract void Interact();
    }
}