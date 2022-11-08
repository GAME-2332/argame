using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

namespace XR {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour {
        public static MainCamera Instance { get; private set; }

        private Transform _transform;
        private Camera _camera;
        private Interaction _hovered;
        private SelectableInteraction _selected;
        
        private void Start() {
            _transform = transform;
            _camera = GetComponent<Camera>();
            
            Instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void Update() {
            if (!GameManager.GameState.IsTracking()) return;
            
            RaycastHit hit;
            if (Physics.Raycast(_transform.position, _transform.forward, out hit)) {
                Interaction hitInteraction = hit.transform.GetComponent<Interaction>();
                if (_hovered != null) _hovered.SetOutline(false);
                _hovered = hitInteraction;
                _hovered.SetOutline(true);
            } else {
                if (_hovered != null) _hovered.SetOutline(false);
                _hovered = null;
            }

            if (GameManager.GameState.IsPlaying() && Input.touchCount >= 1) {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    if (_hovered != null) {
                        ClearSelected();
                        _hovered.Interact();
                    }
                    else {
                        ClearSelected();
                    }
                }
            }
        }

        public void IfSelected(Action<SelectableInteraction> action) {
            if (_selected != null) action.Invoke(_selected);
        }

        [CanBeNull]
        public SelectableInteraction GetSelected() {
            return _selected;
        }

        public void SetSelected(SelectableInteraction interaction) {
            if (_selected != null) _selected.SetOutline(false);
            _selected = interaction;
            
            _selected.SetOutline(true);
        }

        public void ClearSelected() {
            if (_selected != null) _selected.SetOutline(false);
            _selected = null;
        }
    }
}