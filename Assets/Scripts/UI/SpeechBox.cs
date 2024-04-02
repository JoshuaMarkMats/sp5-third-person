using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textObject;
    [SerializeField]
    private GameObject speechBoxObject;

    private Coroutine limitedSpeechBoxCoroutine;

    public string Text
    {
        set { textObject.text = value; }
    }

    private void Start()
    {
        speechBoxObject.SetActive(false);
    }

    public void OpenSpeechBox(string text, float duration)
    {
        Debug.Log("Initiating Limited Speech Box");

        if (limitedSpeechBoxCoroutine != null)
            StopCoroutine(limitedSpeechBoxCoroutine);
        limitedSpeechBoxCoroutine = StartCoroutine(LimitedSpeechBox(text, duration));
    }

    public void OpenSpeechBox(string text)
    {
        if (limitedSpeechBoxCoroutine != null)
            StopCoroutine(limitedSpeechBoxCoroutine);

        speechBoxObject.SetActive(true);
        textObject.text = text;
    }

    public void CloseSpeechBox()
    {
        Debug.Log("Closing all speech boxes");
        if (limitedSpeechBoxCoroutine != null)
            StopCoroutine(limitedSpeechBoxCoroutine);
        speechBoxObject.SetActive(false);
    }

    IEnumerator LimitedSpeechBox(string text, float duration)
    {
        speechBoxObject.SetActive(true);
        textObject.text = text;
        yield return new WaitForSeconds(duration);
        speechBoxObject.SetActive(false);
    }
}
