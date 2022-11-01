using System;
using UnityEngine;

namespace XR {
    public class Board : MonoBehaviour {
        public static Board Instance { get; private set; }

        private void Start() {
            if (Instance != null) Destroy(Instance.gameObject);
            Instance = this;
        }
    }
}