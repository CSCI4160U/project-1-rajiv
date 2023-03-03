using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    //public Armour armour = null;
    public PlayerData playerData = null;
    public SceneData sceneData = null;
    public Player player = null;
    private string savePath;

    private void Start()
    {

        savePath = Application.persistentDataPath + "/saveData/";
        Debug.Log("Saving to path: " + savePath);
        //this.armour = new Armour();
        this.playerData = new PlayerData();


        if (MenuControls.pressedLoadGame)
        {
            LoadGame();
            MenuControls.pressedLoadGame = false;
        }
            
    }

    /*
     * Saves entire game, updates save files
     */
    public void SaveGame()
    {
        //SaveScene();
        SavePlayer();
        //SaveInventory();
        //SaveEnemies();
        //SaveLoot();
        //SaveTreasureChests();

        // save current scene
    }

    /*
     * Loads entire game from last saved files
     */
    public void LoadGame()
    {
        LoadScene();
        LoadPlayer();
        //LoadInventory();
        //LoadEnemies();
        //LoadLoot();
        //LoadTreasureChests();
    }

    [ContextMenu("Save Player")]
    void SavePlayer()
    {
        this.playerData.userName = this.player.userName;
        this.playerData.attack = this.player.attack;
        this.playerData.defense = this.player.defense;
        this.playerData.maxHealth = this.player.maxHealth;
        this.playerData.health = this.player.health;
        this.playerData.playerScore = this.player.playerScore;
        this.playerData.isDead = this.player.isDead;
        this.playerData.playerPosition = this.player.transform.position;

        JSONLoaderSaver.SavePlayerDataAsJSON(savePath, "playerData.json",this.playerData);
        //BinaryLoaderSaver.SavePlayerAsBinary(savePath, "player.bin",this.playerData);
    }
    [ContextMenu("Load Player")]
    void LoadPlayer()
    {
        this.playerData = JSONLoaderSaver.LoadPlayerDataFromJSON(savePath, "playerData.json");

        //this.playerData = BinaryLoaderSaver.LoadPlayerFromBinary(savePath,"player.bin");

        if(playerData != null)
        {
            this.player.userName = playerData.userName;
            this.player.attack = playerData.attack;
            this.player.defense = playerData.defense;
            this.player.maxHealth = playerData.maxHealth;
            this.player.health = playerData.health;
            this.player.playerScore = playerData.playerScore;
            this.player.isDead = playerData.isDead;
            this.player.transform.position = playerData.playerPosition;
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
    void LoadScene()
    {
        this.sceneData = JSONLoaderSaver.LoadSceneDataFromJSON(savePath, "sceneData.json");

        if(sceneData != null)
        {
            if(SceneManager.GetActiveScene().name != sceneData.sceneFullName)
            {
                // switch to correct scene
                SceneManager.LoadScene(sceneData.sceneFullName);
            } 
        }
        else
        {
            Debug.Log("ALERT: No save file exists. Create a New Game!");
        }
    }

}
