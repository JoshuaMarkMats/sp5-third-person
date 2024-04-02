using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [SerializeField]
    private GameObject interactIcon;

    [SerializeField]
    private string[] _speechContents;

    private int chatIndex = 0;

    /// <summary>
    /// Talk to the NPC
    /// </summary>
    /// <returns>true if the NPC has finished speaking</returns>
    public bool Speak()
    {
        if (chatIndex < _speechContents.Length)
        {
            UIController.Instance.speechBox.OpenSpeechBox(_speechContents[chatIndex]);
            chatIndex++;
            return false;
        }

        chatIndex = 0;
        UIController.Instance.speechBox.CloseSpeechBox();
        return true;
    }

    /// <summary>
    /// Resets NPC dialogue and closes speech box
    /// </summary>
    public void StopSpeaking()
    {
        chatIndex = 0;
        UIController.Instance.speechBox.CloseSpeechBox();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        interactIcon.SetActive(true);
    }

    private void OnTriggerExit(Collider collision)
    {
        chatIndex = 0;
        UIController.Instance.speechBox.CloseSpeechBox();
        interactIcon.SetActive(false);
    }*/
}
