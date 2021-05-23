using UnityEngine;

namespace Core.Movement.Type {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Rigidbody2DMovement : Movement {
		protected Rigidbody2D Rigidbody2D;
		
		private void OnEnable() {
			Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		}

		protected override void UpdateRotation(float angleToRotate) {
			Rigidbody2DRotation(angleToRotate);
		}

		/// <summary>
		/// Придать импульс для поворота объекта
		/// </summary>
		/// <param name="angleToRotate">Направление поворота</param>
		protected void Rigidbody2DRotation(float angleToRotate) {
			var rotationImpulse = angleToRotate * (rotationSpeed * Time.deltaTime);
			Rigidbody2D.AddTorque(rotationImpulse);
		}

		protected override void UpdateMovement(Vector2 directionToMove) {
			Rigidbody2DMoving(directionToMove);
		}

		/// <summary>
		/// Придать импульс объекту по направлению
		/// </summary>
		/// <param name="directionToMove">Направление импульса</param>
		protected void Rigidbody2DMoving(Vector2 directionToMove) {
			var movingImpulse = directionToMove * (movementSpeed * Time.deltaTime);
			Rigidbody2D.AddForce(movingImpulse);
		}
	}
}