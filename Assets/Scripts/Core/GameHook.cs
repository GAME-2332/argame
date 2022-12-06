using UnityEngine;

namespace XR {
    /**
     * A hook for code to run within the player from a static context (largely from GameManager). This object exists
     * in the main XR scene.
     */
    public class GameHook : MonoBehaviour {
        private int _queuedLevel = -1;
        
        public void QueueLoadLevel(int level) {
            _queuedLevel = level;
        }

        void Update() {
            if (_queuedLevel != -1) {
                var level = _queuedLevel;
                _queuedLevel = -1;
                GameManager.LoadLevel(level);
            }
        }
    }
}