using UnityEngine;

namespace Core.Score {
	/// <summary>
	/// Необходимо повесить на объект, в случае его уничтожения, будет увеличено количество очков
	/// </summary>
	public class ScorePoints : MonoBehaviour {
		[Tooltip("Количество очков, которое будет добавленно в общий счёт, при отключении объекта")]
		[SerializeField] private int scoreAmount;

		public void SendScore() {
			ScoreStorage.Add(scoreAmount);
		}
	}
}