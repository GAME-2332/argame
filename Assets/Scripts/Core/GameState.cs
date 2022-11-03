namespace XR {
    public enum GameState {
        Playing,
        Paused,
        MainMenu
    }

    static class GameStateMethods {
        public static bool IsPlaying(this GameState state) {
            return state == GameState.Playing;
        }
    }
}