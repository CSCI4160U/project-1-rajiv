using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    public PlayerData playerData = null;
    public SceneData sceneData = null;
    public BossDefeatsData bossDefeatsData = null;
    public SettingsData settingsData = null;
    public Player player = null;
    private string savePath;

    private void Awake()
    {
        // set player userName
        this.player.userName = CreateNewGame.newUserName;
    }

    private void Start()
    {

        savePath = Application.persistentDataPath + "/saveData/";
        Debug.Log("Saving to path: " + savePath);
        this.playerData = new PlayerData();
        this.sceneData = new SceneData();
        this.bossDefeatsData = new BossDefeatsData();
        this.settingsData = new SettingsData();

        // if coming from load game button or entering a door way
        if (!CreateNewGame.pressedCreateGame && !MenuControls.pressedRestartLevel)
        {
            LoadGame();

            if (MenuControls.pressedLoadGame)
            {
                StartCoroutine(LoadScene());
                MenuControls.pressedLoadGame = false;
            }
            if (DoorWay.enteredDoorWay)
            {
                player.transform.position = player.startingPosition.initialValue;
                DoorWay.enteredDoorWay = false;
            }
        }

        if(CreateNewGame.pressedCreateGame || MenuControls.pressedRestartLevel)
        {

            // create new game save files
            SaveGame();

            LoadGame();

            // reset Menu Controls variables
            CreateNewGame.pressedCreateGame = false;
            MenuControls.pressedRestartLevel = false;
            CreateNewGame.newUserName = string.Empty;
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
    }

    /*
     * Loads entire game from last saved files
     */
    public void LoadGame()
    {
        LoadPlayer();
        LoadBossDefeats();
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

            if (!DoorWay.enteredDoorWay && !MenuControls.pressedRestartLevel)
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

        Debug.Log("Saved Scene named: " + sceneData.sceneFullName);

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

    /*
     * Returns true if all existing settings are not null
     */
    private static bool AllSettingsExist()
    {
        return SettingsControls.backgroundMusic != null;
    }
}
