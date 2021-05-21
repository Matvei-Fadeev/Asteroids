using UnityEngine;

namespace Core.Movement.Type {
	public class NonInertialMovement : Movement {
		protected override void UpdateRotation() {
			var currentAngleToRotate = AngleToRotate * (rotationSpeed * Time.deltaTime);
			gameObject.transform.Rotate(currentAngleToRotate);
		}

		protected override void UpdateMovement() {
			var offsetToMove = LocalDirectionToMove * (movementSpeed * Time.deltaTime);
			gameObject.transform.Translate(offsetToMove);
		}
	}
}