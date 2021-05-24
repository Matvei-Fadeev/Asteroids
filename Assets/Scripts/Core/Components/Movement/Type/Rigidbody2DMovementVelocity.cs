using UnityEngine;

namespace Core.Movement.Type {
	public class Rigidbody2DMovementVelocity : Rigidbody2DMovement {
		protected override void UpdateRotation(float angleToRotate) {
			UpdateAngularVelocityDirection(angleToRotate);
		}

		protected override void UpdateMovement(Vector2 directionToMove) {
			UpdateVelocityDirection(directionToMove);
		}

		/// <summary>
		/// Задать направление поворота объекта
		/// </summary>
		/// <param name="angleToRotate">Направление поворота</param>
		private void UpdateAngularVelocityDirection(float angleToRotate) {
			var angularVelocity = angleToRotate * rotationSpeed;
			Rigidbody2D.angularVelocity = Mathf.Lerp(Rigidbody2D.angularVelocity, angularVelocity, Time.deltaTime);
		}

		/// <summary>
		/// Задать направление скорости движения объекта
		/// </summary>
		/// <param name="directionToMove">Направление скорости движения</param>
		private void UpdateVelocityDirection(Vector2 directionToMove) {
			var velocityVector = directionToMove * movementSpeed;
			Rigidbody2D.velocity = velocityVector;
		}
	}
}