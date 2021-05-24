using Core.Components.Movement.Facade;
using UnityEngine;

namespace Core.Components.Movement.Behaviour {
	public class MovementToRandomDirection : FacadeToMovement {
		[Tooltip("Позволяет задать случайное направление поворота.")]
		[SerializeField] private bool enableRandomRotation;
		[Tooltip("Позволяет не только поменять направление движения, но и изменить скорость движения")]
		[SerializeField] private bool enableRandomSpeed;
		[Tooltip("Во сколько раз может уменьшится скорость от изначальной. Изначальная скорость = 1f.")]
		[SerializeField] private float minSpeed = 0.5f;
		[Tooltip("Во сколько раз может увеличиться скорость от изначальной. Изначальная скорость = 1f.")]
		[SerializeField] private float maxSpeed = 2f;

		private void Start() {
			if (enableRandomRotation) {
				SetRandomRotation();
			}
			if (enableRandomSpeed) {
				SetRandomMovingDirectionAndSpeed(minSpeed, maxSpeed);
			}
			else {
				SetRandomMovingDirection();
			}
		}

		/// <summary>
		/// Объект меняет направление поворота в случайную сторону
		/// </summary>
		public void SetRandomRotation() {
			SetAngleToRotate(GetRandomRotation());
		}

		/// <summary>
		/// Объект меняет направление движения в случайную сторону неизменяя скорости
		/// </summary>
		public void SetRandomMovingDirection() {
			SetDirectionToMove(GetRandomNormalizedVector());
		}

		/// <summary>
		/// Объекту задаётся случайное направление и случайная скорость движения в диапозоне 
		/// </summary>
		/// <param name="randomMinSpeed">Минимум возможной скорости. Изначальная скорость = 1f.</param>
		/// <param name="randomMaxSpeed">Максимум возможной скорости. Изначальная скорость = 1f.</param>
		public void SetRandomMovingDirectionAndSpeed(float randomMinSpeed, float randomMaxSpeed) {
			SetDirectionToMove(GetRandomVector(randomMinSpeed,randomMaxSpeed));
		}

		private static Vector2 GetRandomNormalizedVector() {
			return Random.insideUnitCircle.normalized;
		}

		private static Vector2 GetRandomVector(float min, float max) {
			var normalizedVector = GetRandomNormalizedVector();
			var resultedVector = normalizedVector * Random.Range(min, max);
			return resultedVector;
		}

		private static float GetRandomRotation() {
			return Random.rotation.z;
		}
	}
}