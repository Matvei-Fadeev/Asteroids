using Core.Movement.Facade;
using UnityEngine;

namespace Core.Movement.Behaviour {
	public class MovementToRandomDirection : FacadeToMovement {
		[Tooltip("Позволяет не только поменять направление движения, но и изменить скорость движения")]
		[SerializeField] private bool enableRandomSpeed;
		[Tooltip("Во сколько раз может уменьшится скорость от изначальной. Изначальная скорость = 1f.")]
		[SerializeField] private float minSpeed = 0.5f;
		[Tooltip("Во сколько раз может увеличиться скорость от изначальной. Изначальная скорость = 1f.")]
		[SerializeField] private float maxSpeed = 2f;

		private void Start() {
			if (enableRandomSpeed) {
				SetRandomMovingDirectionAndSpeed(minSpeed, maxSpeed);
			}
			else {
				SetRandomMovingDirection();
			}
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
		/// <param name="minSpeed">Минимум возможной скорости. Изначальная скорость = 1f.</param>
		/// <param name="maxSpeed">Максимум возможной скорости. Изначальная скорость = 1f.</param>
		public void SetRandomMovingDirectionAndSpeed(float minSpeed, float maxSpeed) {
			SetDirectionToMove(GetRandomVector(minSpeed,maxSpeed));
		}

		private Vector2 GetRandomNormalizedVector() {
			return UnityEngine.Random.insideUnitCircle.normalized;
		}
		
		private Vector2 GetRandomVector(float min, float max) {
			var normalizedVector = GetRandomNormalizedVector();
			var resultedVector = normalizedVector * UnityEngine.Random.Range(min, max);
			return resultedVector;
		}
	}
}