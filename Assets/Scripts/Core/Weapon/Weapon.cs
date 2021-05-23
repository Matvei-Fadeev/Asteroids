using Input;
using UnityEngine;

namespace Core.Weapon {
	/// <summary>
	/// Объекты данного класса отвечают за стрельбу пулями.
	/// Берут из очереди пули, и выстреливает в нужном направлении.
	/// </summary>
	public class Weapon : MonoBehaviour {
		[SerializeField] private BulletPool bulletPool;
		[SerializeField] private float shotDelay = 0.5f;
		[SerializeField] private bool hasRandomDirection;

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
				var bullet = bulletPool.GetBullet(transform.position);
				bullet.Shoot(GetBulletDirection());
			}
		}

		private Vector3 GetBulletDirection() {
			if (hasRandomDirection) {
				return UnityEngine.Random.insideUnitCircle.normalized;
			}
			return transform.up;
		}
	}
}