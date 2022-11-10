using UnityEngine;
using UnityEngine.Events;

namespace XR {
    public class GameManager {
        /// Triggered when the game state is changing, but before Gamemanager#GameState has actually changed; that
        /// field will still store the old value. The value passed to this event is the new one.
        public static UnityEvent<GameState> GameStateChanged = new();
        
        public static GameState GameState {
            get => _gameState;
            set {
                GameStateChanged.Invoke(value);
                _gameState = value;
            }
        }

        private static GameState _gameState = GameState.Playing;
    }
}
