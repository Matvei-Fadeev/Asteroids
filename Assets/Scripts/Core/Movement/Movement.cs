using System;
using UnityEngine;

namespace Core.Movement {
	public abstract class Movement : MonoBehaviour {
		[Tooltip("Отзеркалить поворот объекта")]
		[SerializeField] protected bool hasReversedRotation = true;

		[SerializeField] protected float movementSpeed = 1;
		[SerializeField] protected float rotationSpeed = 100;

		private float _angleToRotate;
		private Vector2 _directionToMove;

		/// <summary>
		/// Угол, на который будет поворачиваться объект при каждом вызове UpdateRotation
		/// </summary>
		public float AngleToRotate {
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
		/// Локальное направление (по оси объекта), в сторону которого будет двигаться объект
		/// </summary>
		public Vector2 DirectionToMove {
			get => _directionToMove;
			set => _directionToMove = value;
		}
			
		/// <summary>
		/// Применить поворт относительно осей X, Y и Z
		/// </summary>
		protected abstract void UpdateRotation(float angleToRotate);
		/// <summary>
		/// Переместить в направлении и на расстояние LocalDirectionToMove
		/// </summary>
		protected abstract void UpdateMovement(Vector2 directionToMove);

		private void Update() {
			UpdateRotation(_angleToRotate);
			UpdateMovement(_directionToMove);
		}
	}
}