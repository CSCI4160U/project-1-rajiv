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
    public bool requiresKey = false;
    public float requiredDistance = 5f;

    private void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    private void Update()
    {
        CheckIfPlayerHasReachedGoal();
    }

    private void CheckIfPlayerHasReachedGoal()
    {
        if (player != null)
        {

            // get distance between player and goal (has to b within 5)
            float distanceBetween = Vector2.Distance(this.transform.position, player.transform.position);

            // if player is within the required distance and has pressed attack button
            if (distanceBetween <= requiredDistance && Input.GetButtonDown("Fire1"))
            {
                // if player has reached score required
                if (player.playerScore >= scoreRequired)
                {
                    if (requiresKey)
                    {
                        //if (player.hasKey)
                        //{
                        //    // You won the level
                        //}
                    }
                    else
                    {
                        // You met the requirement
                        Debug.Log("You have met the requirement to pass.");

                        playerPositionInCurrentScene.initialValue = playerPositionInDestination.initialValue;

                        SceneManager.LoadScene(destination);
                    }
                }
                else
                {
                    Debug.Log("You need a score of " + scoreRequired + " to progress. CURRENT SCORE: " + player.playerScore + "/" + scoreRequired + ".");
                }
            }

        }
    }
}
