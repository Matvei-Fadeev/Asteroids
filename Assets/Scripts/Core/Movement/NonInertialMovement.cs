using UnityEngine;

namespace Core.Movement {
	public class NonInertialMovement : Movement {
		/// <summary>
		/// Applies a rotation of eulerAngles.z degrees around the z-axis
		/// </summary>
		protected override void UpdateRotation() {
			var currentAngleToRotate = AngleToRotate * (rotationSpeed * Time.deltaTime);
			gameObject.transform.Rotate(currentAngleToRotate);
		}

		/// <summary>
		/// Moves the transform in the direction and distance of translation.
		/// </summary>
		protected override void UpdateMovement() {
			var offsetToMove = LocalDirectionToMove * (movementSpeed * Time.deltaTime);
			gameObject.transform.Translate(offsetToMove);
		}
	}
}