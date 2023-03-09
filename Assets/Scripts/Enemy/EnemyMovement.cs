using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private GameObject player; 
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float hostileRadius = 5f;
    private Enemy enemy;

    private float distanceFromPlayer;

    private void Start()
    {
        enemy = this.GetComponent<Enemy>();
    }

    void Update()
    {
        if (!enemy.isDead)
        {
            Move();
        }        
    }

    public void FollowPlayer()
    {

        // direction the enemy must move in ordeer to get to the player
        Vector2 direction = player.transform.position - transform.position;

        // as long as player is alive
        if (!player.GetComponent<Player>().isDead)
        {
            Debug.Log("x = "+direction.x);
            if (direction.x > 0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }

            // move the enemy towards the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);

            // walk animation
            enemy.DoWalkAnimation();
        }

    }

    // https://www.youtube.com/watch?v=2SXa10ILJms
    public void Move()
    {
        if (player != null)
        {
            // get distance from player 
            distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
            
            

            if(distanceFromPlayer < hostileRadius)
            {
                FollowPlayer();

                
            }
            else
            {
                // reset walking animation
                enemy.StopWalkAnimation();
            }

            if(distanceFromPlayer < this.GetComponent<BoxCollider2D>().edgeRadius)
            {
                enemy.DoAttackAnimation();
            }
            //else
            //{
     
            //    DefaultMovement();
            //}
        }
    }
}
