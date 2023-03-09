using UnityEngine;
using UnityEngine.UI;

public class SettingsControls : MonoBehaviour
{
    private AudioSource backgroundMusic = null;
    [SerializeField] private Slider musicVolumeSlider = null;
    private string savePath;

    public SettingsData settingsData = null;

    private void Awake()
    {
        GameObject bm = GameObject.Find("BackgroundMusic");
        if (bm != null)
        {
            backgroundMusic = bm.GetComponent<AudioSource>();
        }

        musicVolumeSlider.value = musicVolumeSlider.maxValue;
    }

    private void Start()
    {
        savePath = Application.persistentDataPath + "/saveData/";
        Debug.Log("Saving Settings to path: " + savePath);

        // load previously saved settings
        LoadSettings();
    }

    private void FixedUpdate()
    {
        SaveSettings();
        LoadSettings();
    }

    private void Update()
    {
        if(AllSettingsExist())
        {
            UpdateVolume();
        }
    }

    private bool AllSettingsExist()
    {
        return backgroundMusic != null;
    }
    
    private void UpdateVolume()
    {
        backgroundMusic.volume = musicVolumeSlider.value/100;
    }

    [ContextMenu("Save Music Volume")]
    public void SaveSettings()
    {
        if (AllSettingsExist())
        {
            this.settingsData.musicVolume = this.backgroundMusic.volume;
            JSONLoaderSaver.SaveSettingsDataAsJSON(savePath, "settingsData.json", this.settingsData);
        }
    }

    [ContextMenu("Load Music Volume")]
    public void LoadSettings()
    {
        if (AllSettingsExist())
        {
            this.settingsData = JSONLoaderSaver.LoadSettingsDataFromJSON(savePath, "settingsData.json");

            this.backgroundMusic.volume = settingsData.musicVolume;
        }
    }
}
