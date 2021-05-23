using System;
using System.Collections;
using UnityEngine;

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

		// количество углов экрана, точки по краям экрана
		private const int CountOfPoints = 1;

		// Нужен, чтобы объект не стал телепортироваться от стенки к стенке
		private const int Offset = 10;
		private Vector2[] _pointsToSpawn;
		private IEnumerator _coroutine;
		private WaitForSeconds _delayBetweenEnemies;
		private WaitForSeconds _delayBetweenWaves;

		[Serializable]
		struct EnemyGeneration {
			public Transform objectTransform;
			[Range(0f, 1f)] public float chance;
		}

		private void Awake() {
			GenerateSpawnPoints();
		}

		private void OnEnable() {
			_coroutine = InfiniteLoopOfRandomSpawn();
			StartCoroutine(_coroutine);
		}

		private void GenerateSpawnPoints() {
			_pointsToSpawn = new Vector2[CountOfPoints];

			var cam = UnityEngine.Camera.main;


			var leftDown = new Vector2(Offset, Offset);
			_pointsToSpawn[0] = cam.ScreenToWorldPoint(leftDown);
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
			var numberOfPoint = UnityEngine.Random.Range(0, _pointsToSpawn.Length);
			Instantiate(enemyTransform, _pointsToSpawn[numberOfPoint], Quaternion.identity);
		}
	}
}