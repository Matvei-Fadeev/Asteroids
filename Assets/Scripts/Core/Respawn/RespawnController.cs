using System;
using Core.Health;
using UnityEngine;

namespace Core.Respawn {
	public class RespawnController : MonoBehaviour {
		[Tooltip("Позиция, на которую будет перемещён объект")]
		[SerializeField] private Vector3 positionToRespawn;

		[Tooltip("Поворот, который будет иметь объект, при телепортации")]
		[SerializeField] private Quaternion rotationAtRespawn;

		private HealthPoints _health;

		private void Awake() {
			_health = GetComponent<HealthPoints>();
			_health.HealthChangedEventHandler += RespawnObject;
		}

		private void RespawnObject(object sender, int currentHealth) {
			transform.SetPositionAndRotation(positionToRespawn, rotationAtRespawn);
		}

		private void OnDestroy() {
			_health.HealthChangedEventHandler -= RespawnObject;
		}
	}
}