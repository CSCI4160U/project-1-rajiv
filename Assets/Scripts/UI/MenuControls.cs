using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public static bool pressedLoadGame = false;
    public static bool pressedRestartLevel = false;

    public void GoToMainMenu()
    {
        Debug.Log("Opened MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        Debug.Log("Loaded game");

        // bool used in SaveManager.cs to load scene where last saved
        pressedLoadGame = true;

        // IDEA: replace with a scene in limbo, that has a Game Object with SaveManager.cs
        // (Can't work cuz it needs player as a public variable)
        // Change to Loading Scene
        SceneManager.LoadScene("LoadingScene");
        //Debug.Log("Test: " + SaveManager.sceneData.sceneFullName);
    }

    public void QuitWithoutSaving()
    {
        // show warning

        GoToMainMenu();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pressedRestartLevel = true;
        Debug.Log("Trying to restart new game...");
    }
}
