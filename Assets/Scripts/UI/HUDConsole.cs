using UnityEngine;
using System.Collections;
using TMPro;

public class HUDConsole : MonoBehaviour
{
    private GameObject console = null;
    [SerializeField] private TextMeshProUGUI textComponent;
    public static HUDConsole _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        console = this.gameObject;
    }
    private void Start()
    {
        console.SetActive(false);
    }

    public void Log(string message)
    {
        console.SetActive(true);
        _instance.StartCoroutine(ShowMessage(message));
    }

    IEnumerator ShowMessage(string message)
    {
        Debug.Log("Showing message on console...");
        textComponent.text = message;

        yield return new WaitForSeconds(3);

        console.SetActive(false);
        textComponent.text = string.Empty;

    }
}
