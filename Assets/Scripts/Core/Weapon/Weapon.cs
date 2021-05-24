using Input;
using UnityEngine;

namespace Core.Weapon {
	/// <summary>
	/// Объекты данного класса отвечают за стрельбу пулями.
	/// Берут из очереди пули, и выстреливает в нужном направлении.
	/// </summary>
	public class Weapon : MonoBehaviour {
		[Header("Настройки оружия")]
		[SerializeField] private bool hasRandomDirection;
		[SerializeField] private float shotDelay = 0.5f;

		[Header("Обойма")]
		[SerializeField] private BulletPool bulletPool;

		[Header("Настройки пули")]
		[Tooltip("Требуется чтобы пуля не появлялась в объекте")]
		[SerializeField] private float bulletSpawnOffset = 1f;

		private IInputHandler _inputHandler;
		private float _timeOfShot;

		private void Awake() {
			_inputHandler = GetComponent<IInputHandler>();
		}

		private void Update() {
			if (_inputHandler.HasPressedShoot()) {
				TakeShot();
			}
		}

		private void TakeShot() {
			if ((Time.time - _timeOfShot) > shotDelay) {
				_timeOfShot = Time.time;
				
				var transformPosition = transform.position + transform.up * bulletSpawnOffset;
				var bullet = bulletPool.GetBullet(transformPosition);
				bullet.Shoot(GetBulletDirection());
			}
		}

		private Vector3 GetBulletDirection() {
			if (hasRandomDirection) {
				return Random.insideUnitCircle.normalized;
			}
			return transform.up;
		}
	}
}