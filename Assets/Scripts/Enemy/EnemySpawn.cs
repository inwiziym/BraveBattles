using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // префаб противника
    public int maxEnemyCount = 5; // максимальное количество противников на уровне
    private int currentEnemyCount = 0; // текущее количество противников на уровне

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // случайная точка спавна
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
    }
}