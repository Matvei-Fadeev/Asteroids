using Core.Movement.Facade;
using Input;
using UnityEngine;

namespace Core.Movement.Adapters {
	public class AdapterFromInputToMovement : FacadeToMovement {
		private IInputHandler _inputHandler;
		
		protected override void Awake() {
			base.Awake();
			SetInputComponent();
		}

		private void SetInputComponent() {
			_inputHandler = gameObject.GetComponent<IInputHandler>();
		}

		private void Update() {
			SetAngleToRotate(_inputHandler.GetHorizontalInput());
			SetDirectionToMove(new Vector2(0, _inputHandler.GetVerticalInput()));
		}
	}
}