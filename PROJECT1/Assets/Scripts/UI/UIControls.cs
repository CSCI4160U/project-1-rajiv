using UnityEngine;

public class UIControls : MonoBehaviour
{
    private bool pauseMenuIsShown = false;
    private bool deathScreenIsShown = false;

    private void Update()
    {
        TogglePauseMenu(false);
        ShowDeathScreen();
    }

    public void TogglePauseMenu(bool continueGameButtonPressed)
    {
        GameObject pauseMenu = GameObject.Find("PauseMenu");

        if (pauseMenu != null)
        {
            pauseMenu.GetComponent<Canvas>().enabled = pauseMenuIsShown;
        }

        if ((Input.GetKeyDown(KeyCode.Escape) || continueGameButtonPressed))
        {
            Debug.Log("Toggled Pause Menu");
            pauseMenuIsShown = !pauseMenuIsShown; 
        }
    }

    public void ShowDeathScreen()
    {
        GameObject deathScreen = GameObject.Find("DeathScreen");


        if (deathScreen != null) { 
            deathScreen.GetComponent<Canvas>().enabled = deathScreenIsShown;
        }

        if (this.GetComponent<Player>().isDead)
        {
            Debug.Log("Showing Death Screen");
            deathScreenIsShown = true;
        }
        else
        {
            deathScreenIsShown = false;
        }
    }

    public void SetPauseMenuShown(bool value)
    {
        this.pauseMenuIsShown = value;
    }
}
