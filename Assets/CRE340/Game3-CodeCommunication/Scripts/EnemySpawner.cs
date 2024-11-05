using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyTypes;
    public Vector3 spawnArea;
    public float startDelay = 1f;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;
    public int maxSpawnedObjects = 100;

    private List<EnemyBase> spawnedEnemies = new List<EnemyBase>();
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startDelay);

        while (spawnedEnemies.Count < maxSpawnedObjects)
        {
            SpawnRandomEnemy();
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomEnemy()
    {
        if (enemyTypes.Length == 0) return;

        int randomIndex = Random.Range(0, enemyTypes.Length);
        EnemyData selectedEnemyData = enemyTypes[randomIndex];

        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(0, spawnArea.y),
            Random.Range(-spawnArea.z / 2, spawnArea.z /2)
            );

        EnemyBase enemy = EnemyFactory.CreateEnemy(selectedEnemyData, randomPosition);

        if (enemy != null)
        {
            spawnedEnemies.Add(enemy);
        }
    }
}
