using UnityEngine;
using System.Collections;
using TMPro;

public class HUDConsole : MonoBehaviour
{
    private static GameObject console = null;
    public static TextMeshProUGUI textComponent;

    private void Awake()
    {
        console = this.gameObject;
        console.SetActive(false);
    }

    public static IEnumerator ShowMessage(string message)
    {
        textComponent.text = message;
        console.SetActive(true);

        yield return new WaitForSeconds(3);

        console.SetActive(false);
        textComponent.text = string.Empty;

    }
}
