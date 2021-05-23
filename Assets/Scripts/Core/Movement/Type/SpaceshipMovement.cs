using UnityEngine;

namespace Core.Movement.Type {
	public class SpaceshipMovement : Rigidbody2DMovementImpulse {
		[SerializeField] private float stopSpeedOfMoving = 2;
		[SerializeField] private float stopSpeedOfRotation = 10;

		protected override void UpdateRotation(float angleToRotate) {
			if (Mathf.Approximately(angleToRotate, 0f)) {
				DecreaseRotation();
			}
			else {
				Rigidbody2DRotation(angleToRotate);
			}
		}

		/// <summary>
		/// Постепенно снижает скорость поворота до нуля
		/// </summary>
		private void DecreaseRotation() {
			var velocity = Rigidbody2D.angularVelocity;
			Rigidbody2D.angularVelocity = Mathf.Lerp(velocity, 0, Time.deltaTime * stopSpeedOfRotation);
		}

		protected override void UpdateMovement(Vector2 directionToMove) {
			if (directionToMove == Vector2.zero) {
				DecreaseSpeed();
			}
			else {
				ForwardMoving(directionToMove);
			}
		}

		/// <summary>
		/// Постепенно снижает скорость движения до нуля
		/// </summary>
		private void DecreaseSpeed() {
			var velocity = Rigidbody2D.velocity;
			Rigidbody2D.velocity = Vector2.Lerp(velocity, Vector2.zero, Time.deltaTime * stopSpeedOfMoving);
		}

		/// <summary>
		/// Даёт импульс объекту относительно локального оси вверх
		/// </summary>
		/// <param name="localDirectionToMove">Направление движения</param>
		private void ForwardMoving(Vector2 localDirectionToMove) {
			var movingImpulse = localDirectionToMove * (Time.deltaTime * movementSpeed);
			Rigidbody2D.AddForce(transform.up * movingImpulse.y);
			Rigidbody2D.AddForce(transform.right * movingImpulse.x);
		}
	}
}