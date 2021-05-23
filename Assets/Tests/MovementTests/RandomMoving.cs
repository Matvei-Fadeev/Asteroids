using System.Collections;
using Core.Movement;
using Core.Movement.Type;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Core.Movement.Behaviour;

namespace Tests.MovementTests {
	[TestFixture]
	public class RandomMoving {
		private static GameObject _gameObject;
		private static MovementToRandomDirection _randomMoving;
		private static Movement _movement;
		private static Rigidbody2D _rigidbody;

		private static float _microDelay = 0.5f;
		private static float _extraDelay = 2f;

		private static void Reset() {
			// Turn off the las object
			if (_gameObject) {
				_gameObject.SetActive(false);
			}

			_gameObject = new GameObject();

			// Set needed component
			_rigidbody = _gameObject.AddComponent<Rigidbody2D>();
			_movement = _gameObject.AddComponent<Rigidbody2DMovementVelocity>();
			_randomMoving = _gameObject.AddComponent<MovementToRandomDirection>();
			_randomMoving.SetMovement(_movement);
		}

		[SetUp]
		public void Setup() {
			Reset();
		}

		[UnityTest]
		public IEnumerator CheckChangingDirection() {
			var player = _gameObject;
			
			var velocity = _rigidbody.velocity;
			_randomMoving.SetRandomMovingDirection();
			yield return new WaitForSeconds(_microDelay);
			Assert.AreNotEqual(velocity, _rigidbody.velocity);
			
			velocity = _rigidbody.velocity;
			_randomMoving.SetRandomMovingDirection();
			yield return new WaitForSeconds(_microDelay);
			Assert.AreNotEqual(velocity, _rigidbody.velocity);
		}
		
		[UnityTest]
		public IEnumerator CheckChangingDirectionAndSpeed() {
			float minSpeed = 0.5f;
			float maxSpeed = 2f;
			
			var player = _gameObject;
			
			_randomMoving.SetRandomMovingDirection();
			yield return new WaitForSeconds(_extraDelay);
			var velocity = GetMagnitude();
			_randomMoving.SetRandomMovingDirection();
			yield return new WaitForSeconds(_extraDelay);
			Assert.IsTrue(Mathf.Approximately(velocity, GetMagnitude()));
			
			velocity = GetMagnitude();
			_randomMoving.SetRandomMovingDirectionAndSpeed(minSpeed, maxSpeed);
			yield return new WaitForSeconds(_microDelay);
			Assert.IsFalse(Mathf.Approximately(velocity, GetMagnitude()));
		}

		private static float GetMagnitude() {
			return _rigidbody.velocity.magnitude;
		}
	}
}