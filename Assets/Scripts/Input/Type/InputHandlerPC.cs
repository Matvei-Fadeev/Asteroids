using UnityEngine;

namespace Input.Type {
	public class InputHandlerPC : MonoBehaviour, IInputHandler {
		public float GetVerticalInput() {
			return UnityEngine.Input.GetAxis("Vertical");
		}

		public float GetHorizontalInput() {
			return UnityEngine.Input.GetAxis("Horizontal");
		}
	}
}