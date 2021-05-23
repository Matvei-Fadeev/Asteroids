using System.Collections;
using Core.Movement.Facade;
using Core.Movement.Type;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.MovementTests {
	[TestFixture]
	public class MovingToDirection {
		private static GameObject _gameObject;
		private static FacadeToMovement _facadeToMove;
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
			var movement = _gameObject.AddComponent<Rigidbody2DMovement>();
			_facadeToMove = _gameObject.AddComponent<FacadeToMovement>();
			_facadeToMove.SetMovement(movement);
		}

		[SetUp]
		public void Setup() {
			Reset();
		}

		[UnityTest]
		public IEnumerator DoNotMoveWithVectorZero() {
			Vector2 direction = Vector2.zero;

			var defaultPosition = _gameObject.transform.position;
			_facadeToMove.SetDirectionToMove(direction);
			yield return new WaitForSeconds(_frameDelay);

			Assert.IsTrue(Mathf.Approximately(_rigidbody.velocity.magnitude, 0));
		}

		[UnityTest]
		public IEnumerator DoNotMoveWithoutDirection() {
			var player = _gameObject;
			var defaultPosition = player.transform.position;
			yield return new WaitForSeconds(_frameDelay);
			Assert.AreEqual(defaultPosition, player.transform.position);
		}

		private static Vector2[] _directions = {
			Vector2.down,
			Vector2.left,
			Vector2.right,
			Vector2.up,
		};

		[UnityTest]
		public IEnumerator MovingToDirections([ValueSource(nameof(_directions))]
			Vector2 direction) {
			var defaultPosition = _gameObject.transform.position;
			_facadeToMove.SetDirectionToMove(direction);
			yield return new WaitForSeconds(_frameDelay);

			Assert.IsFalse(Mathf.Approximately(_rigidbody.velocity.magnitude, 0));
			Assert.AreNotEqual(1, Vector2.Dot(direction, _rigidbody.velocity));
		}
	}
}