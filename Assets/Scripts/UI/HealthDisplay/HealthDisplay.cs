using Core.Health;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HealthDisplay {
	public class HealthDisplay : MonoBehaviour {
		[SerializeField] private HealthPoints healthPoints;
		[SerializeField] private Text healthPointsText;

		private void OnEnable() {
			SetHealthPointsText(GetHealthPoints());

			healthPoints.HealthChangedEventHandler += SetHealthPointsText;
		}

		private void OnDisable() {
			healthPoints.HealthChangedEventHandler -= SetHealthPointsText;
		}

		private void SetHealthPointsText(int health) {
			healthPointsText.text = health.ToString();
		}

		private void SetHealthPointsText(object sender, int currentHealth) {
			SetHealthPointsText(currentHealth);
		}

		private int GetHealthPoints() {
			return healthPoints.Health;
		}
	}
}