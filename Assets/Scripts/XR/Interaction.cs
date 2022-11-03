using UnityEngine;
using UnityEngine.Internal;

namespace XR {
    [RequireComponent(typeof(Collider), typeof(Renderer))]
    public abstract class Interaction : MonoBehaviour {
        public Outline.Mode outlineMode = Outline.Mode.OutlineAndSilhouette;
        public Color outlineColor = Color.yellow;
        public float outlineWidth = 3f;
        
        private Outline _outline;
        private bool _outlineEnabled;
        
        private void Start() {
            if (_outline == null) {
                _outline = gameObject.AddComponent<Outline>();
                _outline.OutlineMode = outlineMode;
                _outline.OutlineColor = outlineColor;
                _outline.OutlineWidth = outlineWidth;
            }
            
            SetOutline(false);
        }

        public void SetOutline(bool value) {
            _outline.enabled = _outlineEnabled = value;
        }

        public abstract void Interact();
    }
}