using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StarterAssetsInputs))]
public class PlayerInteract : MonoBehaviour
{
    public UnityEvent pickedUpEvent;

    [SerializeField]
    private float interactRange;
    [SerializeField]
    private Vector3 interactOffset = Vector3.up;

    private Collider[] insideInteractRange;
    private Collider _currentInteractable = null;

    private DialogueNPC _currentDialogueNPC;
    private bool isTalking = false;

    private Animator _playerAnimator;
    private StarterAssetsInputs _playerInputs;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Start()
    {
        pickedUpEvent.AddListener(Stats.Instance.AddChineseTakeout);
        pickedUpEvent.AddListener(() => AudioController.Instance.PlaySFX(0));
    }

    private void Update()
    {
        //stop talking to current npc if it goes out of range
        if (_currentDialogueNPC != null && Vector3.SqrMagnitude(_currentDialogueNPC.transform.position - transform.position) > interactRange * interactRange)
        {
            _currentDialogueNPC.StopSpeaking();
            _currentDialogueNPC = null;
        }

        GetClosestInteractable();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + interactOffset, interactRange);
    }

    private void GetClosestInteractable()
    {
        insideInteractRange = Physics.OverlapSphere(transform.position + interactOffset, interactRange);

        foreach (Collider col in insideInteractRange)
        {
            if (col.CompareTag("Collectible"))
            {
                if (_currentInteractable == col)
                    return;

                _currentInteractable = col;
                Debug.Log("Found Interactable: Collectible");
                UIController.Instance.ShowInteract("(E) Pick Up");
                return;
            }
            else if (col.CompareTag("DialogueNPC"))
            {
                if (_currentInteractable == col)
                    return;

                _currentInteractable = col;
                Debug.Log("Found Interactable: DialogueNPC");
                if (!isTalking)
                    UIController.Instance.ShowInteract("(E) Talk");
                return;
            }
            else if (col.CompareTag("Exit"))
            {
                if (_currentInteractable == col)
                    return;

                _currentInteractable = col;
                Debug.Log("Found Interactable: Exit");
                UIController.Instance.ShowInteract("(E) Enter Ship");
                return;
            }
        }

        if (_currentInteractable != null)
        {
            Debug.Log("No interactable found nearby");
            _currentInteractable = null;
            UIController.Instance.ShowInteract("");
        }
    }

    private void OnInteract()
    {
        

        /*foreach (Collider col in insideInteractRange)
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
        }*/
        if (_currentInteractable == null) return;

        switch (_currentInteractable.tag)
        {
            case "Collectible":
                Destroy(_currentInteractable.gameObject);
                pickedUpEvent.Invoke();
                _playerAnimator.SetTrigger("PickUp");
                _playerInputs.crouch = 0f;
                break;
            case "DialogueNPC":
                if (_currentInteractable.TryGetComponent(out DialogueNPC dialogueNPC))
                {
                    isTalking = true;
                    UIController.Instance.ShowInteract("");
                    if (_currentDialogueNPC != null)
                    {
                        if (dialogueNPC.Speak())
                        {
                            _currentDialogueNPC = null;
                            isTalking = false;
                            UIController.Instance.ShowInteract("(E) Talk");
                        }
                    }
                    else
                    {
                        _currentDialogueNPC = dialogueNPC;
                        if (dialogueNPC.Speak())
                        {
                            _currentDialogueNPC = null;
                            isTalking = false;
                            UIController.Instance.ShowInteract("(E) Talk");
                        }
                    }
                }
                break;
            case "Exit":
                LevelController.Instance.NextScene();
                break;
        }
    }
}
