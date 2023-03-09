using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWay : MonoBehaviour
{
    public string destination;
    public Player player = null;
    public VectorValue playerPositionInDestination;

    // stores initial position of player when exiting doorway
    public VectorValue playerPositionInCurrentScene;

    public int scoreRequired = 0;
    public float requiredDistance = 5f;

    public static bool enteredDoorWay = false;

    private void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    private void Update()
    {
        CheckIfPlayerHasReachedGoal();
    }

    private void GoThroughDoorWay()
    {
        // You met the requirement
        Debug.Log("You have met the requirement to pass.");

        playerPositionInCurrentScene.initialValue = playerPositionInDestination.initialValue;

        SceneManager.LoadScene(destination);

        enteredDoorWay = true;
        player.GetComponent<SaveManager>().SaveGame();
    }

    private void CheckIfPlayerHasReachedGoal()
    {
        if (player != null)
        {

            // get distance between player and goal (has to b within 5)
            float distanceBetween = Vector2.Distance(this.transform.position, player.transform.position);

            // if player is within the required distance and has pressed attack button
            if (distanceBetween <= requiredDistance)
            {

                // show hint on how to open door
                transform.GetChild(0).gameObject.SetActive(true);

                // if player has reached score required
                if (player.playerScore >= scoreRequired)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Debug.Log("Went through a door way.");
                        GoThroughDoorWay();
                    }
                }
                else
                {
                    Debug.Log("You need a score of " + scoreRequired + " to progress. CURRENT SCORE: " + player.playerScore + "/" + scoreRequired + ".");
                    HUDConsole._instance.Log("You need a score of " + scoreRequired + " to progress.\n CURRENT SCORE: " + player.playerScore + "/" + scoreRequired + ".");
                }
            }
            else
            {
                // hide hint on how to open door
                transform.GetChild(0).gameObject.SetActive(false);
            }

        }
    }
}
