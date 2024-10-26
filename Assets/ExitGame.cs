using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Method for quitting the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            // If running in the Unity Editor, stop playing
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // If running as a standalone build, quit the application
            Application.Quit();
        #endif
    }
}
