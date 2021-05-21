﻿using Core.Movement.Facade;
using UnityEngine;

namespace Core.Movement.Behaviour {
	public class MovementToTarget : FacadeToMovement {
		[Tooltip("Цель, к которой будет двигаться")]
		[SerializeField] private Transform target;
			
		[Tooltip("Если требуется отключить движение к цели и остановиться")]
		[SerializeField] private bool hasFollowToTarget = true;

		private Vector3 _targetPosition;
		private Vector3 _directionToTarget;

		private void FixedUpdate() {
			UpdateTargetPosition();
			UpdateDirectionToTarget();
			SetLocalDirectionToMove(_directionToTarget);
		}

		private void UpdateTargetPosition() {
			_targetPosition = target.position;
		}

		private void UpdateDirectionToTarget() {
			if (hasFollowToTarget) {
				_directionToTarget = (_targetPosition - transform.position).normalized;
			}
			else {
				_directionToTarget = Vector3.zero;
			}
		}
	}
}