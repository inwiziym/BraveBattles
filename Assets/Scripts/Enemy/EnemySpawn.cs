using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ ����������
    public int maxEnemyCount = 5; // ������������ ���������� ����������� �� ������
    private int currentEnemyCount = 0; // ������� ���������� ����������� �� ������

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // ��������� ����� ������
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
    }
}