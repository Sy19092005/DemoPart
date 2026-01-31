using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnXRange = 2.5f;

    private float lastSpawnTime;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}