using UnityEngine;
#if ENABLE_INPUT_SYSTEM
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

		[Header("Movement Settings")]
		public bool analogMovement;
		public bool lookFromTouch;

        [Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[Header("Shooting Settings")]
		public GameObject projectilePrefab; // The projectile prefab to spawn
		public Transform projectileSpawnpoint; // Projectile spawnpoint
		public float projectileForce = 20f; // Projectile force

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				lookFromTouch = false;
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

		public void OnShoot(InputValue value)
		{
			//Logica de disparo

			Debug.Log("Shoot Action Triggered");
			Shoot();
		}
#endif

		private void Shoot()
		{
			Debug.Log("Real Shoot Done");

			GameObject NewProjectile = Instantiate(projectilePrefab, projectileSpawnpoint.position, transform.rotation);

			NewProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnpoint.forward * 20f, ForceMode.Impulse);
			Destroy(NewProjectile, 5f); // Destroys projectile after 5 seconds
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
			sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}