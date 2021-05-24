using Core.Components.Movement.Facade;
using UnityEngine;

namespace Core.Components.Movement.Behaviour {
	public class MovementToTarget : FacadeToMovement {
		[Tooltip("Если player и есть target")]
		[SerializeField] private bool followToPlayer = true;
		[SerializeField] private string playerTag = "Player";
		[Tooltip("Цель, к которой будет двигаться")]
		[SerializeField] private Transform target;
			
		[Tooltip("Если требуется отключить движение к цели и остановиться")]
		[SerializeField] private bool hasFollowToTarget = true;

		private Vector3 _targetPosition;
		private Vector2 _directionToTarget;

		private void Start() {
			if (followToPlayer) {
				var player = GameObject.FindGameObjectWithTag(playerTag);
				target = player ? player.transform : transform;
			}
		}

		private void FixedUpdate() {
			UpdateTargetPosition();
			UpdateDirectionToTarget();
			SetDirectionToMove(_directionToTarget);
			SetAngleToRotate(_directionToTarget.x);
		}

		private void UpdateTargetPosition() {
			if (target) {
				_targetPosition = target.position;
			}
			else {
				Debug.LogWarning("Target is null");
				target = transform;
			}
		}

		private void UpdateDirectionToTarget() {
			if (hasFollowToTarget) {
				_directionToTarget = (_targetPosition - transform.position).normalized;
			}
			else {
				_directionToTarget = Vector2.zero;
			}
		}
	}
}