using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public static bool pressedLoadGame = false;

    public void GoToMainMenu()
    {
        Debug.Log("Opened MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void CreateNewGame()
    {
        Debug.Log("Created a new game");

        // if save file already exists
            // are you sure you would like to overwrite your saved game?

        // if confirmed
            // go to level 1
            SceneManager.LoadScene("MainScene_Level1");
            //SceneManager.LoadScene("MainScene");
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
}
