using UnityEngine;

namespace Input.Type {
	/// <summary>
	/// Компонент объекта, который через равные промежутки времени нажимает кнопку выстрела
	/// </summary>
	public class ArtificialShooter : MonoBehaviour, IInputHandler {
		[Tooltip("Задержка в секундах между нажатием кнопки выстрела")]
		[SerializeField] private float delayBetweenShooting = 2f;

		private float _timeOfShot;

		public float GetVerticalInput() {
			throw new System.NotImplementedException();
		}

		public float GetHorizontalInput() {
			throw new System.NotImplementedException();
		}

		public bool HasPressedShoot() {
			bool canShoot = (Time.time - _timeOfShot) > delayBetweenShooting;
			if (canShoot) {
				_timeOfShot = Time.time;
			}

			return canShoot;
		}
	}
}