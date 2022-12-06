using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using Util;

namespace XR {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour {
        public static MainCamera Instance { get; private set; }

        private Transform _transform;
        private Camera _camera;
        // private Interaction _hovered;
        // private SelectableInteraction _selected;

        private readonly Singleton<Interaction> _hovered = new(null, s => s.SetOutline(true), s => s.SetOutline(false));
        private readonly Singleton<SelectableInteraction> _selected = new(null, s => s.SetOutline(true), s => s.SetOutline(false));

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
                _hovered.Set(hitInteraction);
            } else {
                _hovered.Clear();
            }

            if (GameManager.GameState.IsPlaying() && Input.touchCount >= 1) {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    if (_hovered.IsPresent()) {
                        ClearSelected();
                        _hovered.Get().Interact();
                    }
                    else ClearSelected();
                }
            }
        }

        public void IfSelected(Action<SelectableInteraction> action) {
            _selected.IfPresent(action);
        }

        [CanBeNull]
        public SelectableInteraction GetSelected() {
            return _selected.Value;
        }

        public void SetSelected(SelectableInteraction interaction) {
            _selected.Set(interaction);
        }

        public void ClearSelected() {
            _selected.Clear();
        }
    }
}