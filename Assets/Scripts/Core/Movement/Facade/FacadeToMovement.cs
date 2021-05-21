using UnityEngine;

namespace Core.Movement.Facade {
	public abstract class FacadeToMovement : MonoBehaviour {
		private Movement _movement;

		protected virtual void Awake() {
			SetMovement();
		}

		private void SetMovement() {
			_movement = gameObject.GetComponent<Movement>();
		}

		/// <summary>
		/// Назначаем локальное направление (по оси объекта), в сторону которого будет двигаться объект
		/// </summary>
		/// <param name="movementLocalDirectionToMove">Вектор направления, в сторону которого будет движение</param>
		protected void SetLocalDirectionToMove(Vector3 movementLocalDirectionToMove) {
			_movement.LocalDirectionToMove = movementLocalDirectionToMove;
		}

		/// <summary>
		/// Угол, на который будет поворачиваться объект при каждом вызове UpdateRotation
		/// </summary>
		/// <param name="movementAngleToRotate">Вектор поворота, в сторону которого будет происходить поворот</param>
		protected void SetAngleToRotate(Vector3 movementAngleToRotate) {
			_movement.AngleToRotate = movementAngleToRotate;
		}
	}
}