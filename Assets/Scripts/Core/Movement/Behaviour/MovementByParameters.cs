using Core.Movement.Facade;
using UnityEngine;

namespace Core.Movement.Behaviour {
	public class MovementByParameters : FacadeToMovement {
		[SerializeField] private float defaultRotation;
		[SerializeField] private Vector2 defaultLocalDirection;

		private void Start() {
			SetParametersToMovement();
		}

		private void SetParametersToMovement() {
			SetAngleToRotate(defaultRotation);
			SetDirectionToMove(defaultLocalDirection);
		}
	}
}