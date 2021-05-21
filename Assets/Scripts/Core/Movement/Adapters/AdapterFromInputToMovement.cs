using Input;
using UnityEngine;

namespace Core.Movement.Adapters {
	public class AdapterFromInputToMovement : MonoBehaviour {
		private Vector3 _directionToRotate;
		private Vector3 _directionToMove;
		private Movement _movement;
		private IInputHandler _inputHandlerPC;

		private void Awake() {
			SetComponents();
		}

		private void Update() {
			ChangeRotationByInput();
			ChangeDirectionByInput();
		}

		private void SetComponents() {
			_movement = gameObject.GetComponent<Movement>();
			_inputHandlerPC = gameObject.GetComponent<IInputHandler>();
		}

		private void ChangeDirectionByInput() {
			UpdateDirectionToMove();
			_movement.LocalDirectionToMove = _directionToMove;
		}

		private void UpdateDirectionToMove() {
			_directionToMove.y = _inputHandlerPC.GetVerticalInput();
		}

		private void ChangeRotationByInput() {
			UpdateDirectionToRotate();
			_movement.AngleToRotate = _directionToRotate;
		}

		private void UpdateDirectionToRotate() {
			_directionToRotate.z = _inputHandlerPC.GetHorizontalInput();
		}
	}
}