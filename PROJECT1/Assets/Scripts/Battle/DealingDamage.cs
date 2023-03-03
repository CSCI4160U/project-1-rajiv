using UnityEngine;
using System.Collections;

public class DealingDamage : MonoBehaviour
{
    public Player player;
    public float attackRange = 1.0f;
    public Transform upAttackPoint;
    public Transform downAttackPoint;
    public Transform leftAttackPoint;
    public Transform rightAttackPoint;
    public LayerMask enemyLayers;

    // damage cool down
    private bool justTookDamage = false;
    

    private void Start()
    {
        StartCoroutine(ResetDamageCoolDown());
    }

    IEnumerator ResetDamageCoolDown()
    {

        // damage cool down for 1 seconds
        yield return new WaitForSeconds(1);

        // now damage can be dealt again
        justTookDamage = false;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        int damage;
        
        // if an enemy is within the player's range
        if (collision.CompareTag("Enemy") && !player.isDead)
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // get distance between player and enemy 
            float distanceBetween = Vector2.Distance(this.transform.position, enemy.transform.position);

            // if attack can do damage, if enemy is within range, if player damage cool down done, and if enemy is alive
            if (player.defense < enemy.attack && !justTookDamage && !enemy.isDead)
            {
                //Debug.Log("Test");
                damage = (enemy.attack - player.defense);

                // deal an attack
                player.health -= damage;

                // enemy attack animation
                enemy.GetComponent<Animator>().SetTrigger("attacked");

                justTookDamage = true;

                player.GetComponent<Animator>().SetTrigger("tookDamage");

                Debug.Log(enemy.enemyName + " has dealt " + damage + " damage to " + player.userName);
            }
            else
            {
                return;
            }

            if (justTookDamage)
            {
                // do damage cool down
                Start();
            }

            if (player.health <= 0)
            {
                player.isDead = true;
                Debug.Log("Game Over: Player is Dead");
            }
        }

    }

    private void Attack()
    {
        Collider2D[] hitEnemies = null;

        if (player.isFacingUp)
        {
            hitEnemies = Physics2D.OverlapCircleAll(upAttackPoint.position, attackRange, enemyLayers);
        }

        if (player.isFacingDown)
        {
            hitEnemies = Physics2D.OverlapCircleAll(downAttackPoint.position, attackRange, enemyLayers);
        }

        if (player.isFacingLeft)
        {
            hitEnemies = Physics2D.OverlapCircleAll(leftAttackPoint.position, attackRange, enemyLayers);
        }

        if (player.isFacingRight)
        {
            hitEnemies = Physics2D.OverlapCircleAll(rightAttackPoint.position, attackRange, enemyLayers);
        }

        
        if(hitEnemies == null)
        {
            return;
        }

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player hit " + enemy.name);
                
            // take a hit from Player
            enemy.GetComponent<Enemy>().TakeHit(player);

            // reset cool down
            justTookDamage = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(upAttackPoint == null || downAttackPoint == null || 
            leftAttackPoint == null || rightAttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(upAttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(downAttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(leftAttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(rightAttackPoint.position, attackRange);
    }
}
