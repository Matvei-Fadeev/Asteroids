using UnityEngine;

namespace Core.Systems.CameraBorderPortal {
	/// <summary>
	/// Данный скрипт, заставляет объект держаться в зоне видимости камеры.
	/// Телепортирует объект, если тот заходит за границы камеры.
	/// </summary>
	public class CameraBorderTeleportation : MonoBehaviour {
		[Tooltip("Если необходим импульс даваемый при телепортации")]
		[SerializeField] private bool hasImpulse = true;
		[Tooltip("Сила импульса даваемый при телепортации")]
		[SerializeField] private float forceImpulse = 0.2f;

		[Tooltip("Дистанция, чтобы игрок выходил за действие видимости камеры")]
		private float deltaDistance = 0.05f;
		
		private Camera _camera;
		private Rigidbody2D _rigidbody;
		
		private void Start() {
			_camera = Camera.main;
			_rigidbody = gameObject.GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate() {
			Vector3 viewPos = _camera.WorldToViewportPoint(transform.position);
			TeleportByAxis(viewPos.x, false);
			TeleportByAxis(viewPos.y, true);
		}

		private void TeleportByAxis(float viewPosAxis, bool reverseAxis) {
			// Этот небольшой оффсет, не даёт увидеть телепортацию объекта
			if (viewPosAxis < -deltaDistance || viewPosAxis > 1 + deltaDistance) {
				// Даём импульс, чтобы объект не застрял на границе, постоянно телепортируясь
				if (_rigidbody && hasImpulse) {
					_rigidbody.AddForce(_rigidbody.velocity.normalized * forceImpulse, ForceMode2D.Impulse);
				}

				transform.position = GetNewPosition(reverseAxis, transform.position);
			}
		}

		private static Vector2 GetNewPosition(bool reverseAxis, Vector3 position) {
			var newPosition = new Vector2(-position.x + float.Epsilon, position.y - float.Epsilon);
			if (reverseAxis) {
				newPosition = -newPosition;
			}

			return newPosition;
		}
	}
}