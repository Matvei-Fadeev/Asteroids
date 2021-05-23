using UnityEngine;

namespace Core.Movement.Type {
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class Rigidbody2DMovement : Movement {
		protected Rigidbody2D Rigidbody2D;
		
		private void Awake() {
			Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		}
	}
}