using Core.Movement.Facade;
using UnityEngine;

namespace Core.Movement.Behaviour {
	public class MovementByParameters : FacadeToMovement {
		[SerializeField] private Vector3 defaultRotation;
		[SerializeField] private Vector3 defaultLocalDirection;

		[Tooltip("Если требуется каждый раз задавать начальные параметры при Update")]
		[SerializeField] private bool isUpdated;

		private void Start() {
			SetParametersToMovement();
		}

		private void FixedUpdate() {
			if (isUpdated) {
				SetParametersToMovement();
			}
		}

		private void SetParametersToMovement() {
			SetAngleToRotate(defaultRotation);
			SetLocalDirectionToMove(defaultLocalDirection);
		}
	}
}