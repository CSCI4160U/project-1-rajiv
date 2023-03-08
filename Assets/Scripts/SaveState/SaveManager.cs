using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    //public Armour armour = null;
    public PlayerData playerData = null;
    public SceneData sceneData = null;
    public BossDefeatsData bossDefeatsData = null;
    public Player player = null;
    private string savePath;

    private void Awake()
    {
        // set player userName
        this.player.userName = MenuControls.newUserName;
    }

    private void Start()
    {

        savePath = Application.persistentDataPath + "/saveData/";
        Debug.Log("Saving to path: " + savePath);
        //this.armour = new Armour();
        this.playerData = new PlayerData();
        this.sceneData = new SceneData();
        this.bossDefeatsData = new BossDefeatsData();

        if (!MenuControls.pressedCreateGame)
        {
            LoadGame();

            if (MenuControls.pressedLoadGame)
            {
                StartCoroutine(LoadScene());
                MenuControls.pressedLoadGame = false;
            }
            if (DoorWay.enteredDoorWay)
            {
                DoorWay.enteredDoorWay = false;
            }
        }
        else
        {
            // create new game save
            SaveGame();
            LoadGame();
            // reset Menu Controls variables
            MenuControls.pressedCreateGame = false;
            MenuControls.newUserName = string.Empty;
        }
    }

    /*
     * Saves entire game, updates save files
     */
    public void SaveGame()
    {
        SavePlayer();
        SaveBossDefeats();
        SaveScene();
        //SaveLoot();
        //SaveTreasureChests();

        // save current scene
    }

    /*
     * Loads entire game from last saved files
     */
    public void LoadGame()
    {
        LoadPlayer();
        LoadBossDefeats();
        //LoadLoot();
        //LoadTreasureChests();
    }

    [ContextMenu("Save Player")]
    public void SavePlayer()
    {
        this.playerData.userName = this.player.userName;
        this.playerData.attack = this.player.GetAttackPower();
        this.playerData.defense = this.player.GetDefense();
        this.playerData.maxHealth = this.player.maxHealth;
        this.playerData.health = this.player.GetCurrentHealth();
        this.playerData.playerScore = this.player.playerScore;
        this.playerData.isDead = this.player.isDead;

        if (!DoorWay.enteredDoorWay)
        {
            this.playerData.playerPosition = this.player.transform.position;
        }
        

        JSONLoaderSaver.SavePlayerDataAsJSON(savePath, "playerData.json",this.playerData);
        //BinaryLoaderSaver.SavePlayerAsBinary(savePath, "player.bin",this.playerData);
    }
    [ContextMenu("Load Player")]
    public void LoadPlayer()
    {
        this.playerData = JSONLoaderSaver.LoadPlayerDataFromJSON(savePath, "playerData.json");

        //this.playerData = BinaryLoaderSaver.LoadPlayerFromBinary(savePath,"player.bin");

        if(playerData != null)
        {
            this.player.userName = playerData.userName;
            this.player.SetAttackPower(playerData.attack);
            this.player.SetDefense(playerData.defense);
            this.player.maxHealth = playerData.maxHealth;
            this.player.SetHealth(playerData.health);
            this.player.playerScore = playerData.playerScore;
            this.player.isDead = playerData.isDead;

            if (!DoorWay.enteredDoorWay)
            {
                this.player.transform.position = playerData.playerPosition;
            }
        }
    }

    [ContextMenu("Save Scene")]
    void SaveScene()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        this.sceneData.sceneFullName = activeSceneName;
        this.sceneData.sceneType = activeSceneName.Split("_")[0];
        this.sceneData.levelName = activeSceneName.Split("_")[1];

        Debug.Log("Saved Scene name: " + sceneData.sceneFullName);
        Debug.Log("Current Level: " + sceneData.levelName);

        JSONLoaderSaver.SaveSceneDataAsJSON(savePath, "sceneData.json", this.sceneData);
        //BinaryLoaderSaver.SavePlayerAsBinary(savePath, "player.bin",this.playerData);
    }
    [ContextMenu("Load Scene")]
    IEnumerator LoadScene()
    {
        this.sceneData = JSONLoaderSaver.LoadSceneDataFromJSON(savePath, "sceneData.json");
        
        yield return new WaitForSeconds(5);

        if (sceneData != null)
        {
            if(SceneManager.GetActiveScene().name != sceneData.sceneFullName)
            {
                // switch to correct scene
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneData.sceneFullName);

                while (!asyncOperation.isDone)
                {
                    yield return null;
                }

            } 
        }
        else
        {
            Debug.Log("ALERT: No save file exists. Create a New Game!");
        }
    }

    [ContextMenu("Save BossDefeats")]
    void SaveBossDefeats()
    {
        this.bossDefeatsData.bossesDefeatedNames = player.bossesDefeatedNames;
        this.bossDefeatsData.bossesDefeatedScenes = player.bossesDefeatedScenes;

        JSONLoaderSaver.SaveBossDefeatsDataAsJSON(savePath, "bossDefeatsData.json", this.bossDefeatsData);
        //BinaryLoaderSaver.SavePlayerAsBinary(savePath, "player.bin",this.playerData);
    }
    [ContextMenu("Load BossDefeats")]
    void LoadBossDefeats()
    {
        this.bossDefeatsData = JSONLoaderSaver.LoadBossDefeatsDataFromJSON(savePath, "bossDefeatsData.json");

        //this.playerData = BinaryLoaderSaver.LoadPlayerFromBinary(savePath,"player.bin");

        if (bossDefeatsData != null)
        {
            player.bossesDefeatedNames = bossDefeatsData.bossesDefeatedNames;
            player.bossesDefeatedScenes = bossDefeatsData.bossesDefeatedScenes;
        }

        for(int i = 0; i < player.bossesDefeatedNames.Count; i++)
        {
            GameObject bossDefeated = GameObject.Find(player.bossesDefeatedNames[i]);

            // if currentBoss is an Enemy present in the scene
            if (bossDefeated != null && bossDefeated.GetComponent<Enemy>() != null 
                && SceneManager.GetActiveScene().name == player.bossesDefeatedScenes[i])
            {
                // hide boss that was already defeated
                bossDefeated.SetActive(false);
            }
        }
    }
}