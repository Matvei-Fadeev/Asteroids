using Core.Components.Health;
using UnityEngine;

namespace Core.Systems.Damageable {
	public class DamageableCollision : MonoBehaviour {
		[SerializeField] private int damage = 1;
		
		protected virtual void OnCollisionEnter2D(Collision2D collision) {
			var objectHealth = collision.gameObject.GetComponent<HealthPoints>();
			if (objectHealth) {
				objectHealth.Hit(damage);
			}
		}
	}
}