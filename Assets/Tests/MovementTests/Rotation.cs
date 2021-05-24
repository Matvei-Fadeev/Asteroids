using System.Collections;
using Core.Components.Movement;
using Core.Components.Movement.Facade;
using Core.Components.Movement.Type;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.MovementTests {
	[TestFixture]
	public class Rotation {
		private static GameObject _gameObject;
		private static FacadeToMovement _facadeToMove;
		private static Movement _movement;
		private static Rigidbody2D _rigidbody;
		private static float _frameDelay = 0.5f;

		private static void Reset() {
			// Turn off the las object
			if (_gameObject) {
				_gameObject.SetActive(false);
			}

			_gameObject = new GameObject();

			// Set needed component
			_rigidbody = _gameObject.AddComponent<Rigidbody2D>();
			_movement = _gameObject.AddComponent<Rigidbody2DMovementImpulse>();
			_facadeToMove = _gameObject.AddComponent<FacadeToMovement>();
			_facadeToMove.SetMovement(_movement);
		}

		[SetUp]
		public void Setup() {
			Reset();
		}

		[UnityTest]
		public IEnumerator DoNotRotate() {
			float rotation = 0f;

			_facadeToMove.SetAngleToRotate(rotation);
			yield return new WaitForSeconds(_frameDelay);

			Assert.IsTrue(Mathf.Approximately(_rigidbody.angularVelocity, 0));
		}

		[UnityTest]
		public IEnumerator DoNotRotateWithoutDirection() {
			var player = _gameObject;
			var defaultRotation = player.transform.rotation;
			yield return new WaitForSeconds(_frameDelay);
			Assert.AreEqual(defaultRotation, player.transform.rotation);
		}

		[UnityTest]
		public IEnumerator RotationToLeft() {
			float directionToRotate = -1f;
			var player = _gameObject;
			var defaultRotationZ = player.transform.rotation.z;
			_facadeToMove.SetAngleToRotate(directionToRotate);
			yield return new WaitForSeconds(_frameDelay);

			// Т.к. hasReversedRotation = true
			Assert.IsTrue(defaultRotationZ < player.transform.rotation.z);
		}

		[UnityTest]
		public IEnumerator RotatingToRight() {
			float directionToRotate = +1f;
			var player = _gameObject;
			var defaultRotationZ = player.transform.rotation.z;
			_facadeToMove.SetAngleToRotate(directionToRotate);
			yield return new WaitForSeconds(_frameDelay);

			// Т.к. hasReversedRotation = true
			Assert.IsTrue(defaultRotationZ > player.transform.rotation.z);
		}
	}
}