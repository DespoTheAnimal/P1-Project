using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneChange 
{
    /// <summary>
    /// Load the next scene in the build settings
    /// </summary>
    /// <param name="currentScene">The currently active scene</param>
    public static void LoadNextScene(int currentScene)
    {
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    /// <summary>
    /// Restart the active scene
    /// </summary>
    /// <param name="currentScene">The active scene</param>
    public static void RestartScene (int currentScene)
    {
        SceneManager.LoadScene(currentScene);
    } 
}
