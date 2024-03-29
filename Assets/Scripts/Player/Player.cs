using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class Player : MonoBehaviour
{
    // Values are increased In-Game if weapons or defense boosts are equipped
    private int currentAttack;
    private int currentDefense;
    private int health;

    public string userName;

    public int defaultAttack = 25;
    public int defaultDefense = 10;
    public int maxHealth = 100;
    public int playerScore;

    public bool isFacingUp;
    public bool isFacingDown;
    public bool isFacingLeft;
    public bool isFacingRight;

    public bool isDead;

    public VectorValue startingPosition;

    // stores Enemy names
    public List<string> bossesDefeatedNames;

    // store Scene names where Enemy was defeated
    public List<string> bossesDefeatedScenes;

    [SerializeField] private AudioSource takeDamageSoundEffect;

    public void Awake()
    {
        // initialize player variables
        currentAttack = defaultAttack;
        currentDefense = defaultDefense;
        health = maxHealth;
        isDead = false;
        bossesDefeatedNames = new List<string>();
        bossesDefeatedScenes = new List<string>();
    }




    public void TakeHit(Enemy enemy)
    {
        int damage = (enemy.attack - this.currentDefense);

        if(damage > 0)
        {
            health -= damage;

            // enemy attack animation
            enemy.GetComponent<Animator>().SetTrigger("attacked");

            Debug.Log(enemy.enemyName + " has dealt " + damage + " damage to " + userName);

            // show message in console for 3 seconds
            HUDConsole._instance.Log(enemy.enemyName + " has dealt " + damage + " damage to " + userName, 3f);

            this.GetComponent<Animator>().SetTrigger("tookDamage");
            takeDamageSoundEffect.Play();
        }
    }

    public void UpdateHealthSlider()
    {
        GameObject healthSlider = GameObject.Find("HealthSlider");

        if (healthSlider != null)
        {
            healthSlider.GetComponent<Slider>().maxValue = maxHealth;
            healthSlider.GetComponent<Slider>().value = health;
        }
    }

    public void UpdatePlayerScore()
    {
        GameObject scoreNumber = GameObject.Find("ScoreNumber");

        if (scoreNumber != null)
        {
            scoreNumber.GetComponent<TMP_Text>().text = playerScore.ToString();
        }
        
    }

    private void Update()
    {
        UpdateHealthSlider();
        UpdatePlayerScore();
    }

    // Getters and Setters

    public int GetAttackPower()
    {
        return currentAttack;
    }

    public void SetAttackPower(int newAttack)
    {
        currentAttack = newAttack;
    }

    public int GetDefense()
    {
        return currentDefense;
    }

    public void SetDefense(int newDefense)
    {
        currentDefense = newDefense;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public void Heal(int healthBoost)
    {
        health += healthBoost;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
