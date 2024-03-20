using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonController))]
[RequireComponent(typeof(StarterAssetsInputs))]
public class Player : MonoBehaviour
{
    private Animator _playerAnimator;
    private StarterAssetsInputs _input;

    [SerializeField]
    private GameObject _flashlight;
    private bool _flashlightOn = false;

    private ThirdPersonController _playerController;

    private const string TURN_ON_FLASHLIGHT_PARAMETER = "TurnOnFlashlight";
    private const string TURN_OFF_FLASHLIGHT_PARAMETER = "TurnOffFlashlight";

    private void Awake()
    {
        _playerController = GetComponent<ThirdPersonController>();
        _playerAnimator = GetComponent<Animator>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Start()
    {
        _input.ToggleFlashlightEvent.AddListener(ToggleFlashlight);
    }

    private void ToggleFlashlight()
    {
        if (!_playerController.CanMove)
            return;

        _flashlightOn = !_flashlightOn;
        _playerAnimator.SetTrigger(_flashlightOn ? TURN_ON_FLASHLIGHT_PARAMETER : TURN_OFF_FLASHLIGHT_PARAMETER);
        _flashlight.SetActive(_flashlightOn);
    }
}
