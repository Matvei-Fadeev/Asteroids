using Core.Score;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScoreDisplay {
	public class ScoreDisplay : MonoBehaviour {
		/// <summary>
		/// Текст, который будет содержать в себе количество очков
		/// </summary>
		[SerializeField] private Text scoreText;

		private void OnEnable() {
			SetScoreText(ScoreStorage.CurrentScore);
			ScoreStorage.ScoreUpdatedEvent += SetScoreText;
		}

		private void OnDisable() {
			ScoreStorage.ScoreUpdatedEvent -= SetScoreText;
		}

		private void SetScoreText(int newScore) {
			scoreText.text = newScore.ToString();
		}

		private void SetScoreText(object sender, int currentHealth) {
			SetScoreText(currentHealth);
		}
	}
}