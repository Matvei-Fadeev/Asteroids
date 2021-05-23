using System;
using Core.Movement.Facade;
using UnityEngine;

namespace Core.Movement.Behaviour {
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
				target = GameObject.FindGameObjectWithTag(playerTag).transform;
			}
		}

		private void FixedUpdate() {
			UpdateTargetPosition();
			UpdateDirectionToTarget();
			SetDirectionToMove(_directionToTarget);
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