using Core.Movement.Facade;
using Input;
using UnityEngine;

namespace Core.Movement.Adapters {
	public class AdapterFromInputToMovement : FacadeToMovement {
		private IInputHandler _inputHandlerPC;
		
		protected override void Awake() {
			base.Awake();
			SetInputComponent();
		}

		private void SetInputComponent() {
			_inputHandlerPC = gameObject.GetComponent<IInputHandler>();
		}

		private void Update() {
			SetAngleToRotate(new Vector3(0, 0, _inputHandlerPC.GetHorizontalInput()));
			SetLocalDirectionToMove(new Vector3(0, _inputHandlerPC.GetVerticalInput()));
		}
	}
}