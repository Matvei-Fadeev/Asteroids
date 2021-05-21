using UnityEngine;

namespace Core.Movement {
	public abstract class Movement : MonoBehaviour {
		[Tooltip("Отзеркалить поворот объекта")]
		[SerializeField] protected bool hasReversedRotation = true;

		[SerializeField] protected float movementSpeed;
		[SerializeField] protected float rotationSpeed;

		private Vector3 _angleToRotate;

		/// <summary>
		/// Угол, на который будет поворачиваться объект при каждом вызове UpdateRotation
		/// </summary>
		public Vector3 AngleToRotate {
			get => _angleToRotate;
			set {
				if (hasReversedRotation) {
					_angleToRotate = -value;
				}
				else {
					_angleToRotate = value;
				}
			}
		}

		/// <summary>
		/// Локальное направление, в сторону которого будет двигаться объект
		/// </summary>
		public Vector3 LocalDirectionToMove { get; set; }

		protected abstract void UpdateRotation();
		protected abstract void UpdateMovement();

		private void Update() {
			UpdateRotation();
			UpdateMovement();
		}
	}
}