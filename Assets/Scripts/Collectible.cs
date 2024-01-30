using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    private bool isInRangeOfPlayer = false;

    public UnityEvent pickedUpEvent;

    private GameController gameController;
    //private UIScript uiController;

    private void Start()
    {
        pickedUpEvent.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIScript>().AddAmmo);

        //uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIScript>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.itemPickedUpEvent.AddListener(PickUpItem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRangeOfPlayer=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRangeOfPlayer = false;
        }
    }

    private void PickUpItem()
    {
        if (isInRangeOfPlayer) 
        {
            pickedUpEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
