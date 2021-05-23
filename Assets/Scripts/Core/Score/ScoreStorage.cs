using System;
using UnityEngine;

namespace Core.Score {
	/// <summary>
	/// Класс хранящий и обрабатывающий логику score
	/// </summary>
	public static class ScoreStorage {
		/// <summary>
		/// Event уведомляющий об изменении количества очков
		/// </summary>
		public static event EventHandler<int> ScoreUpdatedEvent;

		/// <summary>
		/// Текущее количество очков
		/// </summary>
		public static int CurrentScore {
			get => _currentScore;
			private set {
				_currentScore = value;
				ScoreUpdatedEvent?.Invoke(null, _currentScore);
			}
		}

		private static int _currentScore = 0;

		/// <summary>
		/// Добавляет очки к текущему количеству
		/// </summary>
		/// <param name="score">Количетво очков, которые будут добавлены</param>
		public static void Add(int score) {
			CurrentScore += score;
		}

		/// <summary>
		/// Обнуление очков
		/// </summary>
		public static void Reset() {
			CurrentScore = 0;
		}
	}
}