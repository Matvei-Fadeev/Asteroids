using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadScene {
	/// <summary>
	/// Предназначается для загрузки сцен, управления загрузкой
	/// </summary>
	public class LoadManager : MonoBehaviour {
		public static void ReloadCurrentScene() {
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}
	}
}