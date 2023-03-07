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
    public List<string> bossesDefeatedNames = new List<string>();

    // store Scene names where Enemy was defeated
    public List<string> bossesDefeatedScenes = new List<string>();

    private void Awake()
    {
        currentAttack = defaultAttack;
        currentDefense = defaultDefense;
        health = maxHealth;

        if (startingPosition != null)
        {
            this.transform.position = startingPosition.initialValue;
        }
    }



    public void TakeHit(Enemy enemy)
    {
        int damage = (enemy.attack - this.currentDefense);

        if(damage > 0)
        {
            health -= damage;
            Debug.Log(enemy.enemyName + " has dealt " + damage + " damage to " + userName);
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
