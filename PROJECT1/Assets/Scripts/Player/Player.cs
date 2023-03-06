using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    public string userName;
    public int attack;
    public int defense;
    public int maxHealth = 100;
    public int health;
    public int playerScore;
    public bool isFacingUp;
    public bool isFacingDown;
    public bool isFacingLeft;
    public bool isFacingRight;
    public bool isDead;
    public VectorValue startingPosition;

    private void Start()
    {
        this.transform.position = startingPosition.initialValue;
    }



    public void TakeHit(Enemy enemy)
    {
        int damage = (enemy.attack - this.defense);

        if(damage > 0)
        {
            health -= damage;
            Debug.Log(enemy.enemyName + " has dealt " + damage + " damage to " + userName);
        }
    }

    public void UpdateHealthSlider()
    {
        GameObject healthSlider = GameObject.Find("HealthSlider");
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
        healthSlider.GetComponent<Slider>().value = health;
    }

    public void UpdatePlayerScore()
    {
        GameObject scoreNumber = GameObject.Find("ScoreNumber");
        scoreNumber.GetComponent<TMP_Text>().text = playerScore.ToString();
    }

    private void Update()
    {
        UpdateHealthSlider();
        UpdatePlayerScore();
    }
}
