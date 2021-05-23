using UnityEngine;

namespace Core.Score {
	/// <summary>
	/// Необходимо повесить на объект, в случае его уничтожения, будет увеличено количество очков
	/// </summary>
	public class ScorePoints : MonoBehaviour {
		[Tooltip("Количество очков, которое будет добавленно в общий счёт, при отключении объекта")]
		[SerializeField] private int scoreAmount;

		[Tooltip("Случа, при которых будут добавлены очки")]
		[SerializeField] private WhenAddScore whenAddScore;

		private enum WhenAddScore {
			NONE,
			ONDISABLE,
			ONDESTROY,
		}

		private void OnDisable() {
			if (whenAddScore == WhenAddScore.ONDISABLE) {
				ScoreStorage.Add(scoreAmount);
			}
		}

		private void OnDestroy() {
			if (whenAddScore == WhenAddScore.ONDESTROY) {
				ScoreStorage.Add(scoreAmount);
			}
		}
	}
}