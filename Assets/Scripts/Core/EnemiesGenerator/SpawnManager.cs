using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.EnemiesGenerator {
	/// <summary>
	/// Компонент, поставить на объект, который будет генерировать другие объекты в точке с заданной вероятностью.
	/// </summary>
	public class SpawnManager : MonoBehaviour {
		[Tooltip("Задержка спавна между каждым существом")]
		[SerializeField] private float delayBetweenEnemies = 2f;

		[Tooltip("Задержка спавна между волнами, т.е. в конце спавна всех существ.")]
		[SerializeField] private float delayBetweenWaves = 10f;

		[SerializeField] private EnemyGeneration[] enemiesCfg;

		// Нужен, чтобы объект не стал телепортироваться от стенки к стенке
		private const int Offset = 10;
		private IEnumerator _coroutine;
		private WaitForSeconds _delayBetweenEnemies;
		private WaitForSeconds _delayBetweenWaves;

		[Serializable]
		struct EnemyGeneration {
			public Transform objectTransform;
			[Range(0f, 1f)] public float chance;
		}

		private void OnEnable() {
			_coroutine = InfiniteLoopOfRandomSpawn();
			StartCoroutine(_coroutine);
		}
		
		/// <returns>Позиция спавна сбоку или скраю</returns>
		private Vector2 GetRandomPositionOnBorder() {
			// Разрешение экрана
			var camWidth = UnityEngine.Camera.main.scaledPixelWidth;
			var camHeight = UnityEngine.Camera.main.scaledPixelHeight;
			
			// Из 9 случаев не подходит, когда спавн в центре экрана, нужен сбоку или скраю
			var badCase = new Vector2(camWidth / 2, camHeight / 2);
			Vector2 position = badCase;
			while (position == badCase) {
				var width = GetRandomLength(camWidth);
				var height = GetRandomLength(camHeight);
				position = new Vector2(width, height);
			}

			// Переводит из координат экрана в мировые
			var worldPoint = UnityEngine.Camera.main.ScreenToWorldPoint(position);
			return worldPoint;
		}

		/// <param name="displayLength">размер экрана в ширину или в длину</param>
		/// <returns>Получаем края левый или правый, либо центр</returns>
		private float GetRandomLength(float displayLength) {
			float[] length = {0, displayLength / 2, displayLength};
			int number = Random.Range(0, length.Length);
			return length[number];
		}

		private void OnDisable() {
			if (_coroutine != null) {
				StopCoroutine(_coroutine);
			}
		}

		private IEnumerator InfiniteLoopOfRandomSpawn() {
			_delayBetweenEnemies = new WaitForSeconds(delayBetweenEnemies);
			_delayBetweenWaves = new WaitForSeconds(delayBetweenWaves);
			while (true) {
				foreach (var enemyCfg in enemiesCfg) {
					bool isSpawned = UnityEngine.Random.value > enemyCfg.chance;

					if (isSpawned) {
						SpawnObject(enemyCfg.objectTransform);
						yield return _delayBetweenEnemies;
					}
				}

				yield return _delayBetweenWaves;
			}
		}

		private void SpawnObject(Transform enemyTransform) {
			var positionToSpawn = GetRandomPositionOnBorder();
			Instantiate(enemyTransform, positionToSpawn, Quaternion.identity);
		}
	}
}