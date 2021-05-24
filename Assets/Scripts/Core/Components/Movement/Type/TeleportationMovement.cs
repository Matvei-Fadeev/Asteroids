using UnityEngine;

namespace Core.Components.Movement.Type {
	public class TeleportationMovement : Movement {
		protected override void UpdateRotation(float angleToRotate) {
			var currentAngleToRotate = angleToRotate * (rotationSpeed * Time.deltaTime);
			gameObject.transform.Rotate(new Vector3(0, 0, currentAngleToRotate));
		}

		protected override void UpdateMovement(Vector2 directionToMove) {
			var offsetToMove = directionToMove * (movementSpeed * Time.deltaTime);
			gameObject.transform.Translate(offsetToMove);
		}
	}
}