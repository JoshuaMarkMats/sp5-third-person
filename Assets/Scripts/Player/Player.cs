using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonController))]
[RequireComponent(typeof(StarterAssetsInputs))]
public class Player : MonoBehaviour, IDamageable
{
    private Animator _playerAnimator;
    private StarterAssetsInputs _input;

    [SerializeField]
    private GameObject _flashlight;
    private bool _flashlightOn = false;

    private ThirdPersonController _playerController;

    private bool _isAlive = true;

    public bool IsAlive { get { return _isAlive; } }

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

    private void Update()
    {
        if (_flashlightOn && _input.crouch > 0)
            ToggleFlashlight();
    }

    public void TakeDamage(int damage)
    {
        GameController.Instance.GameOver();
    }

    private void ToggleFlashlight()
    {
        if (!_playerController.CanMove || _input.crouch > 0)
            return;

        _flashlightOn = !_flashlightOn;
        _playerAnimator.SetTrigger(_flashlightOn ? TURN_ON_FLASHLIGHT_PARAMETER : TURN_OFF_FLASHLIGHT_PARAMETER);
        _flashlight.SetActive(_flashlightOn);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
