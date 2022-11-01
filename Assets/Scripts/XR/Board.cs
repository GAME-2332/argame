using System;
using UnityEngine;

namespace XR {
    public class Board : MonoBehaviour {
        private static GameObject _prefab;
        private static Transform _followTarget;
        
        public static Board Instance { get; private set; }

        private Transform _transform;

        public static Board GetOrCreate() {
            if (Instance == null) {
                if (_prefab == null) _prefab = Resources.Load("Prefabs/Game Board") as GameObject;
                Instance = Instantiate(_prefab).GetComponent<Board>();
                Instance._transform.localScale = new Vector3(.05f, .05f, .05f);
            }
            return Instance;
        }

        public static void SetActive(bool active) {
            GetOrCreate().gameObject.SetActive(active);
        }

        public static void SetFollowTarget(Transform target) {
            GetOrCreate();
            
            _followTarget = target;
            Instance._transform.position = target.position;
            Instance._transform.rotation = target.rotation;
        }

        public static void ClearFollowTarget() {
            _followTarget = null;
        }
        
        private void Start() {
            if (Instance != null && Instance != this) Destroy(Instance.gameObject);
            Instance = this;
            
            _transform = transform;
        }

        private void Update() {
            if (_followTarget != null) {
                _transform.position = _followTarget.position;
                _transform.rotation = _followTarget.rotation;
            }
        }
    }
}