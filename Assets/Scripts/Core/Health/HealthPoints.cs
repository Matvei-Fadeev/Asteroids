using System;
using UnityEngine;

namespace Core.Health {
	public class HealthPoints : MonoBehaviour {
		/// <summary>
		/// Событие вызываемое каждый раз при изменении здоровья
		/// </summary>
		public event EventHandler<int> HealthChangedEventHandler;

		/// <summary>
		/// Событие вызываемое при смерти
		/// </summary>
		public event EventHandler IsDieEventHandler;

		[Tooltip("Допустимое максимальное здоровье, которое будет даваться при старте объекту")] 
		[SerializeField] private int maxHealth;

		private int _health;

		public int Health {
			get => _health;
			private set {
				_health = value;
				HealthChangedEventHandler?.Invoke(this, _health);
				if (_health <= 0) {
					IsDieEventHandler?.Invoke(this, EventArgs.Empty);
					SetDeath();
				}
				else if (maxHealth < _health) {
					_health = maxHealth;
				}
			}
		}

		public int MAXHealth => maxHealth;

		private void Awake() {
			Health = maxHealth;
		}

		private void SetDeath() {
			Destroy(gameObject);
		}

		public void Hit(int damage) {
			Health -= damage;
		}
	}
}