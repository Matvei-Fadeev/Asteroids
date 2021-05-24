using Core.Components.Movement.Facade;
using UnityEngine;

namespace Core.Components.Movement.Behaviour {
	public class MovementByParameters : FacadeToMovement {
		[SerializeField] private float startingRotation;
		[SerializeField] private Vector2 startingDirectionToMove;

		private void Start() {
			SetParametersToMovement();
		}

		private void SetParametersToMovement() {
			SetAngleToRotate(startingRotation);
			SetDirectionToMove(startingDirectionToMove);
		}
	}
}