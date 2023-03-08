using UnityEngine;
using System.Collections;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    IEnumerator TextAnimation()
    {
        TMP_Text loadingText = this.GetComponentInChildren<TMP_Text>();

        loadingText.text = "LOADING";
        yield return new WaitForSeconds(0.4f);
        loadingText.text = "LOADING.";
        yield return new WaitForSeconds(0.4f);
        loadingText.text = "LOADING..";
        yield return new WaitForSeconds(0.4f);
        loadingText.text = "LOADING...";
        yield return new WaitForSeconds(0.4f);

        Start();
    }

    private void Start()
    {
        StartCoroutine(TextAnimation());
    }
    private void Update()
    {
        
    }
}
