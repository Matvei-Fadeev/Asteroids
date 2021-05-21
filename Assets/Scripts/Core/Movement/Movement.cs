using System;
using UnityEngine;

namespace Core.Movement {
	public abstract class Movement : MonoBehaviour {
		[Tooltip("Отзеркалить поворот объекта")]
		[SerializeField] protected bool hasReversedRotation = true;

		[SerializeField] protected float movementSpeed;
		[SerializeField] protected float rotationSpeed;

		private Vector3 _angleToRotate;
		private Vector3 _localDirectionToMove;

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
		/// Локальное направление (по оси объекта), в сторону которого будет двигаться объект
		/// </summary>
		public Vector3 LocalDirectionToMove {
			get => _localDirectionToMove;
			set => _localDirectionToMove = value;
		}

		/// <summary>
		/// Применить поворт относительно осей X, Y и Z
		/// </summary>
		protected abstract void UpdateRotation();
		/// <summary>
		/// Переместить в направлении и на расстояние LocalDirectionToMove
		/// </summary>
		protected abstract void UpdateMovement();

		private void Update() {
			UpdateRotation();
			UpdateMovement();
		}
	}
}