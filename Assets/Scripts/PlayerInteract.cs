using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    //private GameController gameController;
    public UnityEvent pickedUpEvent;

    [SerializeField]
    private float interactRange;
    [SerializeField]
    private Vector3 interactOffset = Vector3.up;

    private Collider[] insideInteractRange;

    private void Start()
    {
        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        pickedUpEvent.AddListener(Stats.Instance.AddChineseTakeout);
        pickedUpEvent.AddListener(AudioController.Instance.PlayAmmoPickupSound);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + interactOffset, interactRange);
    }

    private void OnInteract()
    {
        insideInteractRange = Physics.OverlapSphere(transform.position + interactOffset, interactRange);

        foreach (Collider col in insideInteractRange)
        {
            if (col.CompareTag("Collectible"))
            {
                Destroy(col.gameObject);
                pickedUpEvent.Invoke();
                break;
            }
        }
        //gameController.itemPickedUpEvent.Invoke();
    }
}
