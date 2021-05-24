using System;
using Core.Health;
using LoadScene;
using UnityEngine;

namespace Core.Managers.GameOver {
    /// <summary>
    /// GameOver в случае уведомления target о смерти
    /// </summary>
    public class GameOver : MonoBehaviour {
        [Header("Зависимые объекты")]
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject gameOverUI;

        [Header("Параметры GameOver")]
        [Tooltip("Время после которого произойдёт рестарт")]
        [SerializeField] private float timeToRestart = 4f;
        
        private void OnEnable() {
            var health = target.GetComponent<HealthPoints>();
            if (health) {
                health.IsDieEventHandler += SetGameOver;
            }
            else {
                SetGameOver();
            }
        }

        /// <summary>
        /// Перезагрузить текущую сцену
        /// </summary>
        public void RestartGame() {
            Debug.Log("Click");
            LoadManager.ReloadCurrentScene();
        }

        private void SetGameOver(object sender, EventArgs e) {
            SetGameOver();
        }

        /// <summary>
        ///  Показать экран GameOver
        /// </summary>
        private void SetGameOver() {
            gameOverUI.SetActive(true);
            Invoke(nameof(RestartGame), timeToRestart);
        }
    }
}
