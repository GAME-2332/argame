using Unity.VisualScripting;

namespace XR {
    public enum GameState {
        Playing,
        Shop,
        Paused,
        MainMenu
    }

    static class GameStateMethods {
        public static bool IsPlaying(this GameState state) {
            return state == GameState.Playing;
        }

        /// Whether the game is rendering and performing XR tracking (anywhere but the main menu)
        public static bool IsTracking(this GameState state) {
            return state != GameState.MainMenu;
        }
    }
}