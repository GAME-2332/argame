using System;
using Persistence;
using UnityEngine;
using UnityEngine.Events;

namespace XR {
    public class GameManager {
        /// Triggered when the game state is changing, but before Gamemanager#GameState has actually changed; that
        /// field will still store the old value. The value passed to this event is the new one.
        public static event Action<GameState> GameStateChanged = delegate { };
        /// Triggered when the level changes; the new level is passed to this event.
        /// Invoked after level loading and deserialization.
        public static event Action<int> LevelChanged = delegate { };
        
        public static int Level => _level;
        public static GameState GameState {
            get => _gameState;
            set {
                GameStateChanged.Invoke(value);
                _gameState = value;
            }
        }

        private static int _level = -1;
        private static GameState _gameState = GameState.Playing;

        public static void LoadLevel(int level) {
            if (_level == -1) SaveManager.DeserializeAll();
            else SaveManager.SerializeAll();
            
            Board.LoadLevel(level);
            _level = level;
            // Deserialize again in case new objects have been created upon level load that need deserialization
            SaveManager.DeserializeAll();
            
            LevelChanged.Invoke(level);
        }
    }
}
