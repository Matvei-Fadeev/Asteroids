using System.Collections;
using Core.Movement;
using Core.Movement.Facade;
using Core.Movement.Type;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.MovementTests {
	[TestFixture]
	public class SpaceshipRotateAndMoving {
		private static GameObject _gameObject;
		private static FacadeToMovement _facadeToMove;
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
			_movement = _gameObject.AddComponent<SpaceshipMovement>();
			_facadeToMove = _gameObject.AddComponent<FacadeToMovement>();
			_facadeToMove.SetMovement(_movement);
		}

		[SetUp]
		public void Setup() {
			Reset();
		}

		public struct InputOutput {
			public Vector2 direction;
			public float rotation;
			public bool positiveYAxis;
			public bool positiveXAxis;

			public InputOutput(Vector2 direction, float rotation, bool positiveYAxis, bool positiveXAxis) {
				this.direction = direction;
				this.rotation = rotation;
				this.positiveYAxis = positiveYAxis;
				this.positiveXAxis = positiveXAxis;
			}
		}

		private static InputOutput[] _inputOutputsTestCase = {
			//new InputOutput{ Vector2.up, 1f, true, true }
			new InputOutput(Vector2.up, 1f, true, true),
			new InputOutput(Vector2.up, -1f, true, false),
			new InputOutput(Vector2.down, 1f, false, false),
			new InputOutput(Vector2.down, -1f, false, true),
		};

		[UnityTest]
		public IEnumerator RotationToLeftAndMoveForward([ValueSource(nameof(_inputOutputsTestCase))]
			InputOutput testData) {
			Vector2 forwardDirection = testData.direction;
			float directionToRotate = testData.rotation;

			var player = _gameObject;
			var defaultPosition = player.transform.position;
			_facadeToMove.SetAngleToRotate(directionToRotate);
			yield return new WaitForSeconds(_microDelay);

			_facadeToMove.SetDirectionToMove(forwardDirection);
			yield return new WaitForSeconds(_microDelay);

			var actualPosition = player.transform.position;
			Assert.AreEqual((defaultPosition.y < actualPosition.y), testData.positiveYAxis);
			Assert.AreEqual((defaultPosition.x < actualPosition.x), testData.positiveXAxis);
		}

		private static Vector2[] _directions = {
			Vector2.up, Vector2.right, Vector2.down, Vector2.left
		};

		[UnityTest]
		public IEnumerator AutoStopMoving([ValueSource(nameof(_directions))]
			Vector2 direction) {
			var player = _gameObject;
			var defaultPosition = player.transform.position;

			var lastVelocity = GetAbsVelocity();
			_facadeToMove.SetDirectionToMove(direction);
			yield return new WaitForSeconds(_microDelay);
			//Assert.IsTrue(lastVelocity < GetAbsVelocity());
			Assert.Greater(GetAbsVelocity(), lastVelocity);

			lastVelocity = GetAbsVelocity();
			_facadeToMove.SetDirectionToMove(Vector2.zero);
			yield return new WaitForSeconds(_extraDelay);
			//Assert.IsTrue(lastVelocity > GetAbsVelocity());
			Assert.Less(GetAbsVelocity(), lastVelocity);
		}

		private static float GetAbsVelocity() {
			return Mathf.Abs(_rigidbody.velocity.magnitude);
		}

		[UnityTest]
		public IEnumerator AutoStopRotation([Values(-1f, 1f)] float rotation) {
			var rotationDirection = rotation;

			var player = _gameObject;
			var defaultPosition = player.transform.position;

			var lastVelocity = GetAbsAngularVelocity();
			_facadeToMove.SetAngleToRotate(rotationDirection);
			yield return new WaitForSeconds(_microDelay);
			Assert.IsTrue(lastVelocity < GetAbsAngularVelocity());

			lastVelocity = GetAbsAngularVelocity();
			_facadeToMove.SetAngleToRotate(0f);
			yield return new WaitForSeconds(_extraDelay);
			Assert.IsTrue(lastVelocity > GetAbsAngularVelocity());
		}

		private static float GetAbsAngularVelocity() {
			return Mathf.Abs(_rigidbody.angularVelocity);
		}
	}
}