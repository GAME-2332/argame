using UnityEngine;

namespace XR {
    public class MainCamera : MonoBehaviour {
        public static MainCamera Instance { get; private set; }
        
        private void Start() {
            Instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}