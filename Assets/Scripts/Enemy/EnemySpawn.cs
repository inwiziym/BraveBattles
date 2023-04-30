using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnInterval = 15f; // �������� ������ ������
    public float pointSpawnX;
    public float pointSpawnY;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(pointSpawnX, pointSpawnY), Quaternion.identity);
    }
}