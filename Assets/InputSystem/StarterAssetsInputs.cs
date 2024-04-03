using UnityEngine;
using UnityEngine.Events;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public float crouch = 0f;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = false;
		public bool cursorInputForLook = true;

		public bool gamePaused = false;

		public UnityEvent ToggleFlashlightEvent;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnCrouch()
		{
			crouch = crouch > 0f ? 0f : 1f;
		}

		public void OnPause()
		{
			if (!GameController.Instance.IsGameOver) GameController.Instance.TogglePause();
		}

		public void OnToggleFlashlight()
		{
			ToggleFlashlightEvent.Invoke();
		}
#endif


		private void OnApplicationFocus(bool hasFocus)
		{

			Cursor.lockState = (GameController.Instance.GamePaused || GameController.Instance.IsGameOver) ? CursorLockMode.None : CursorLockMode.Locked;

        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			crouch = 0f;
			sprint = newSprintState;
		}
	}
	
}