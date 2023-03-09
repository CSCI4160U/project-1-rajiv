using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int attack;
    public int defense;
    public int maxHealth = 50;
    public int health;
    public bool isDead = false;
    public int numberOfLives;
    public float reviveTime;
    public int value;


    public void Start()
    {
        health = maxHealth;
    }

    // https://www.youtube.com/watch?v=sPiVz1k-fEs
    public void TakeHit(Player player)
    {
        if (!isDead)
        {
            int damage = (player.GetAttackPower() - this.defense);
            if (damage > 0)
            {
                health -= damage;
                Debug.Log(player.userName + " has dealt " + damage + " damage to " + enemyName);

                // show message in console
                HUDConsole._instance.Log(player.userName + " has dealt " + damage + " damage to " + enemyName);

                // take damage animation
                this.GetComponent<Animator>().SetTrigger("tookDamage");
            }


            if (health <= 0)
            {
                Die();
                isDead = true;
                numberOfLives -= 1;

                if (RanOutOfLives())
                {
                    // add to bosses defeated, with its corresponding scene
                    player.bossesDefeatedNames.Add(gameObject.name);
                    player.bossesDefeatedScenes.Add(SceneManager.GetActiveScene().name);
                }

                // increase player score
                player.playerScore += value;
            }
        }  
    }

    private bool RanOutOfLives()
    {
        if(numberOfLives == 0)
        {
            // hide game object
            this.gameObject.SetActive(false);

            return true;
        }
        return false;
    }

    private void Die()
    {
        Debug.Log(enemyName + " has been defeated!");

        // show message in console
        HUDConsole._instance.Log(enemyName + " has been defeated!");

        // do death animation
        this.GetComponent<Animator>().SetTrigger("isDead");

        // disable Player from being able to hit enemy
        this.GetComponent<Collider2D>().enabled = false;

        // disable element
        this.enabled = false;
        
    }

    public void DoWalkAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("isWalking");
    }

    public void StopWalkAnimation()
    {
        this.GetComponent<Animator>().ResetTrigger("isWalking");
    }

    public void DoAttackAnimation()
    {
        // do death animation
        this.GetComponent<Animator>().SetTrigger("attacked");
    }

    public void Revive()
    {
        // now damage can be dealt again
        isDead = false;

        // make enemy alive
        this.GetComponent<Animator>().ResetTrigger("isDead");

        // enable Player from being able to hit enemy
        this.GetComponent<Collider2D>().enabled = true;

        // enable element
        this.enabled = true;

        // reset health
        Start();
    }

    private void Update()
    {
        RanOutOfLives();
    }
}
