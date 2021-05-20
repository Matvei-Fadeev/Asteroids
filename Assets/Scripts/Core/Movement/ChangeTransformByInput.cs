using UnityEngine;

namespace Core.Movement {
	public class ChangeTransformByInput : MonoBehaviour {
		private Movement _movement;
		private Vector3 _directionToRotate;
		private Vector3 _directionToMove;

		private void Awake() {
			_movement = gameObject.GetComponent<Movement>();
		}

		private void Update() {
			ChangeRotationByInput();
			ChangeDirectionByInput();
		}

		private void ChangeDirectionByInput() {
			UpdateDirectionToMove();
			_movement.LocalDirectionToMove = _directionToMove;
		}

		private void UpdateDirectionToMove() {
			_directionToMove.y = GetVerticalInput();
		}

		private void ChangeRotationByInput() {
			UpdateDirectionToRotate();
			_movement.AngleToRotate = _directionToRotate;
		}

		private void UpdateDirectionToRotate() {
			_directionToRotate.z = GetHorizontalInput();
		}
		
		private static float GetVerticalInput() {
			return Input.GetAxis("Vertical");
		}

		private static float GetHorizontalInput() {
			return Input.GetAxis("Horizontal");
		}
	}
}