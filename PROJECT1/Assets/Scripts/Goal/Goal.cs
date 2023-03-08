using UnityEngine;

public class Goal : MonoBehaviour
{
    public Player player = null;
    public Vector3 goalPosition;
    public int scoreRequired = 0;
    public bool requiresKey = false;
    public float requiredDistance = 5f;

    private void Start()
    {
        goalPosition = this.transform.position;
    }
    private void Update()
    {
        CheckIfPlayerHasReachedGoal();
    }

    private void CheckIfPlayerHasReachedGoal()
    {
        if(player != null)
        {

            // get distance between player and goal (has to b within 5)
            float distanceBetween = Vector2.Distance(goalPosition, player.transform.position);

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
                        // You won the level
                        Debug.Log("You have passed the level");
                    }
                }
                else
                {
                    Debug.Log("You need a score of "+scoreRequired+" to progress. CURRENT SCORE: "+player.playerScore+"/"+scoreRequired+".");
                }
            }
            
        }
    }

}
