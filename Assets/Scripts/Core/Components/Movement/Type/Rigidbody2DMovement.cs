using UnityEngine;

namespace Core.Components.Movement.Type {
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class Rigidbody2DMovement : Movement {
		protected Rigidbody2D Rigidbody2D;
		
		private void Awake() {
			Rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}