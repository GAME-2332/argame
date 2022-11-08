﻿using JetBrains.Annotations;
using UnityEngine;

namespace XR {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour {
        public static MainCamera Instance { get; private set; }

        private Transform _transform;
        private Camera _camera;
        private Interaction _hovered;
        
        private void Start() {
            _transform = transform;
            _camera = GetComponent<Camera>();
            
            Instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void Update() {
            if (!GameManager.GameState.IsPlaying()) return;
            
            RaycastHit hit;
            if (Physics.Raycast(_transform.position, _transform.forward, out hit)) {
                Interaction hitInteraction = hit.transform.GetComponent<Interaction>();
                if (_hovered != null) _hovered.SetOutline(false);
                _hovered = hitInteraction;
                if (_hovered != null) _hovered.SetOutline(true);
            } else {
                if (_hovered != null) _hovered.SetOutline(false);
                _hovered = null;
            }

            if (_hovered != null) {
                // TODO: Interaction code
            }
        }
    }
}