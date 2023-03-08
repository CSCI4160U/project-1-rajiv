using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    Level[] levels = new Level[] { 
        new Level("LVL 1",0,0,0),
        new Level("LVL 2",1000,2,2),
        new Level("LVL 3",5000,4,2),
        new Level("LVL 4",10000,6,3),
        new Level("LVL 5",15000,8,4),
        new Level("LVL 6",20000,10,5),
        new Level("LVL 7",25000,12,6),
        new Level("LVL 8",30000,14,7),
        new Level("LVL 9",40000,16,8),
        new Level("LVL 10",50000,20,10),
    };

    public Player player = null;

    private void Update()
    {
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        GameObject levelSlider = GameObject.Find("LevelSlider");
        GameObject currentLvlInHUD = GameObject.Find("CurrentLevel");
        GameObject nextLvlInHUD = GameObject.Find("NextLevel");

        if (player != null)
        {
            int nextLevelIndex = getNextLevelIndex(player.playerScore);

            Level currentLvl = levels[nextLevelIndex - 1];
            Level nextLvl = levels[nextLevelIndex];

            // Updating Slider
            if(levelSlider != null)
            {
                levelSlider.GetComponent<Slider>().maxValue = nextLvl.scoreRequired - currentLvl.scoreRequired;
                levelSlider.GetComponent<Slider>().value = player.playerScore - currentLvl.scoreRequired;
            }

            // Updating Text in HUD
            if(currentLvlInHUD != null && nextLvlInHUD != null)
            {
                currentLvlInHUD.GetComponent<TMP_Text>().text = currentLvl.levelName;
                nextLvlInHUD.GetComponent<TMP_Text>().text = nextLvl.levelName;
            }

            Debug.Log("---NEW LEVEL ACQUIRED---");
            Debug.Log(player.userName + " has reached " +currentLvl+"!");
            Debug.Log("\n"+ player.userName + " now has:");

            // Updating Player Attack
            player.SetAttackPower(currentLvl.attackBoost + player.defaultAttack);

            Debug.Log("+" + currentLvl.attackBoost + " Attack ["+"Current Attack = "+player.GetAttackPower()+"]");

            // Updating Player Defense
            player.SetDefense(currentLvl.defenseBoost + player.defaultDefense);

            Debug.Log("+" + currentLvl.defenseBoost + " Defense [" + "Current Defense = " + player.GetDefense() + "]");
        }

    }

    private int getNextLevelIndex(int playerScore)
    {
        int result = 0;
        for(int i = 0; i < levels.Length; i++)
        {
            if(playerScore < levels[i].scoreRequired) {
                result = i;
                break;
            }
        }

        return result;
    }
}
