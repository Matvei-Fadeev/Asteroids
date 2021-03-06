using Core.Components.Movement.Facade;
using Input;
using UnityEngine;

namespace Core.Components.Movement.Adapter {
	public class AdapterFromInputToMovement : FacadeToMovement {
		private IInputHandler _inputHandler;
		
		protected override void Awake() {
			base.Awake();
			SetInputComponent();
		}

		private void SetInputComponent() {
			_inputHandler = GetComponent<IInputHandler>();
		}

		private void Update() {
			SetAngleToRotate(_inputHandler.GetHorizontalInput());
			SetDirectionToMove(new Vector2(0, _inputHandler.GetVerticalInput()));
		}
	}
}