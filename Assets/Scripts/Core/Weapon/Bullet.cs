using Core.Damageable;
using UnityEngine;

namespace Core.Weapon {
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(BoxCollider2D))]
	public class Bullet : DamageableCollision {
		[SerializeField] private float speed = 10f;
		[SerializeField] private float maxLifetime = 2f;

		private BulletPool _bulletPool;
		private Rigidbody2D _rigidbody;

		private void Awake() {
			_bulletPool = GetComponentInParent<BulletPool>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		protected override void OnCollisionEnter2D(Collision2D collision) {
			base.OnCollisionEnter2D(collision);
			_bulletPool.ReturnBullet(this);
		}

		/// <summary>
		/// Привести пулю в движение
		/// </summary>
		/// <param name="direction">Направление в котором полетит пуля</param>
		public void Shoot(Vector2 direction) {
			transform.SetParent(null);
			_rigidbody.velocity = direction * speed;
			Invoke(nameof(ReturnToPool), maxLifetime);
		}

		private void ReturnToPool() {
			_bulletPool.ReturnBullet(this);
		}
	}
}