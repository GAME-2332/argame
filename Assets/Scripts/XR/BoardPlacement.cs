using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace XR {
    [RequireComponent(typeof(ARRaycastManager))]
    public class BoardPlacement : MonoBehaviour {
        public Camera camera;
        public GameObject boardPrefab;

        private ARRaycastManager _raycastManager;
        private Depth _depth;
        private List<ARRaycastHit> _hits = new();
        private Board _board;
        private bool _finalized;

        private void Start() {
            _raycastManager = GetComponent<ARRaycastManager>();
            _depth = camera.GetComponent<Depth>();
        }

        private void Update() {
            if (Input.touchCount < 1) return;// || _finalized) return;
            
            var touch = Input.GetTouch(0);
            if (_depth.UpdateDepthTexture()) {
                Debug.Log("Using depth buffer for board placement");
                
                Vector3 viewportPoint = camera.ScreenToViewportPoint(touch.position);
                viewportPoint.z = _depth.GetPointDepth(viewportPoint);
                Vector3 worldPoint = camera.ViewportToWorldPoint(viewportPoint);
                Debug.Log("Viewport coordinates: " + viewportPoint.x + ", " + viewportPoint.y + "\nDepth: " + viewportPoint.z + "\nWorld point: " + worldPoint);
                
                if (viewportPoint.z > 0) HandleTouch(touch, worldPoint + Vector3.up * .05f);
            }
            // // Plane-based board placement
            // else if (_raycastManager.Raycast(touch.position, _hits)) {
            //     Debug.Log("Using plane raycast for board placement");
            //     
            //     var hit = _hits[0];
            //     HandleTouch(touch, hit.pose.position);
            // }
        }

        private void HandleTouch(Touch touch, Vector3 worldPos) {
            switch (touch.phase) {
                case TouchPhase.Began:
                    SpawnBoard(worldPos);
                    break;
                case TouchPhase.Moved:
                    MoveBoard(worldPos);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    FinalizeBoard();
                    break;
            }
        }

        private void SpawnBoard(Vector3 position) {
            if (_board == null) _board = Instantiate(boardPrefab, position, Quaternion.identity).GetComponent<Board>();
        }
        
        private void MoveBoard(Vector3 position) {
            if (_board != null) _board.transform.position = position;
        }

        private void FinalizeBoard() {
            _finalized = true;
        }
    }
}