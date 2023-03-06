using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public static bool chestIsOpen = false;
    public Player player = null;

    private void Update()
    {
        ToggleOpenChest();
        CloseChest();
        this.GetComponentInChildren<Canvas>().enabled = chestIsOpen;
    }

    private void ToggleOpenChest()
    {
        // get distance between player and goal (has to b within 5)
        float distanceBetween = Vector2.Distance(this.transform.position, player.transform.position);

        if(distanceBetween < 1 && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Toggled Chest");
            chestIsOpen = true;
        }
        
    }

    private void CloseChest()
    {
        if (Input.GetKeyDown(KeyCode.Q) && chestIsOpen)
        {
            chestIsOpen = false;
        }
    }
}
