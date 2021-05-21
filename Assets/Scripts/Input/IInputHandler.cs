namespace Input {
	public interface IInputHandler {
		/// <returns>Возвращает значение смещения от виртуальной оси по вертикали</returns>
		float GetVerticalInput();

		/// <returns>Возвращает значение смещения от виртуальной оси по горизонтале</returns>
		float GetHorizontalInput();
	}
}