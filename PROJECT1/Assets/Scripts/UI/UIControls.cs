using UnityEngine;

public class UIControls : MonoBehaviour
{
    private bool inventoryIsShown = false;
    private bool pauseMenuIsShown = false;
    private bool deathScreenIsShown = false;

    private void Update()
    {
        TogglePauseMenu(false);
        ToggleInventory();
        ShowDeathScreen();
    }

    public void ToggleInventory()
    {
        GameObject.Find("Inventory").GetComponent<Canvas>().enabled = inventoryIsShown;

        // if "i" pressed and pause menu isn't shown
        if (Input.GetKeyDown("i") && !pauseMenuIsShown)
        {
            Debug.Log("Toggled Inventory");
            inventoryIsShown = !inventoryIsShown;
            
        }
        
    }

    public void TogglePauseMenu(bool continueGameButtonPressed)
    {
        GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = pauseMenuIsShown;

        if (Input.GetKeyDown(KeyCode.Escape) || continueGameButtonPressed)
        {
            Debug.Log("Toggled Pause Menu");
            pauseMenuIsShown = !pauseMenuIsShown; 
        }
    }

    public void ShowDeathScreen()
    {
        GameObject.Find("DeathScreen").GetComponent<Canvas>().enabled = deathScreenIsShown;

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
}
