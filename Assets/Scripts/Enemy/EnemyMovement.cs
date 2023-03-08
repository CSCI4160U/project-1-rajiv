using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private GameObject player; 
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float hostileRadius = 5f;

    // direction the enemy is moving along x axis
    private int xDirection = -1;

    private float distanceFromPlayer;
    private bool reset = false;

    IEnumerator ChangeDefaultWalkingDirection()
    {

        // wait 2 seconds
        yield return new WaitForSeconds(2);

        xDirection *= -1;

        Start();
    }

    private void Start()
    {
        StartCoroutine(ChangeDefaultWalkingDirection());
        reset = false;
    }

    void DefaultMovement()
    {
        if (reset)
        {
            Start();
        }
        transform.Translate(Vector3.right * (xDirection * movementSpeed * Time.deltaTime));
        transform.localScale = new Vector3(xDirection, 1);
    }

    void Update()
    {
        if (!this.GetComponent<Enemy>().isDead)
        {
            Move();
        }        
    }

    public void FollowPlayer()
    {
        // as long as player is alive
        if (!player.GetComponent<Player>().isDead)
        {
            //Vector3 direction = player.transform.position - transform.position;

            //this.GetComponent<Rigidbody2D>().MovePosition(transform.position + (movementSpeed * Time.deltaTime * direction));
            // move the enemy towards the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            //transform.Translate(direction * movementSpeed * Time.deltaTime);

            // walk animation
        }

    }

    // https://www.youtube.com/watch?v=2SXa10ILJms
    public void Move()
    {
        if (player != null)
        {
            // get distance from player 
            distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
            
            //// direction the enemy must move in ordeer to get to the player
            //Vector2 direction = player.transform.position - transform.position;

            if(distanceFromPlayer < hostileRadius)
            {
                FollowPlayer();
            }
            //else
            //{
     
            //    DefaultMovement();
            //}
        }
    }
}
