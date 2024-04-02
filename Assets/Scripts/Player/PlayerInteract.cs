using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInteract : MonoBehaviour
{
    public UnityEvent pickedUpEvent;

    [SerializeField]
    private float interactRange;
    [SerializeField]
    private Vector3 interactOffset = Vector3.up;

    private Collider[] insideInteractRange;

    private DialogueNPC _currentDialogueNPC;

    private Animator _playerAnimator;
    

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        pickedUpEvent.AddListener(Stats.Instance.AddChineseTakeout);
        pickedUpEvent.AddListener(AudioController.Instance.PlayAmmoPickupSound);
    }

    private void Update()
    {
        //stop talking to current npc if it goes out of range
        if (_currentDialogueNPC != null && Vector3.SqrMagnitude(_currentDialogueNPC.transform.position - transform.position) > interactRange * interactRange)
        {
            _currentDialogueNPC.StopSpeaking();
            _currentDialogueNPC = null;
        }
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
                _playerAnimator.SetTrigger("PickUp");
                break;
            }
            else if (col.TryGetComponent(out DialogueNPC dialogueNPC))
            {
                if (_currentDialogueNPC != null)
                {
                    if (dialogueNPC.Speak()) _currentDialogueNPC = null;
                }
                else
                {
                    _currentDialogueNPC = dialogueNPC;
                    if (dialogueNPC.Speak()) _currentDialogueNPC = null;
                }
                break;
            }
        }
    }
}
