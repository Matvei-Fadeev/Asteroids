using System;
using UnityEngine;

namespace Core.Movement.Facade {
	public class FacadeToMovement : MonoBehaviour {
		private Movement _movement;

		/// <summary>
		/// Назначаем Movement компонент
		/// </summary>
		protected virtual void Awake() {
			SetMovement();
		}

		public void SetMovement(Movement movement) {
			_movement = movement;
		}

		private void SetMovement() {
			_movement = gameObject.GetComponent<Movement>();
		}

		/// <summary>
		/// Назначаем локальное направление (по оси объекта), в сторону которого будет двигаться объект
		/// </summary>
		/// <param name="movementLocalDirectionToMove">Вектор направления, в сторону которого будет движение</param>
		public void SetDirectionToMove(Vector2 movementLocalDirectionToMove) {
			_movement.DirectionToMove = movementLocalDirectionToMove;
		}

		/// <summary>
		/// Угол, на который будет поворачиваться объект при каждом вызове UpdateRotation
		/// </summary>
		/// <param name="movementAngleToRotate">Вектор поворота, в сторону которого будет происходить поворот</param>
		public void SetAngleToRotate(float movementAngleToRotate) {
			_movement.AngleToRotate = movementAngleToRotate;
		}
	}
}