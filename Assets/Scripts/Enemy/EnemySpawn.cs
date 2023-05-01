using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnInterval; // �������� ������ ������
    public float pointSpawnX1;
    public float pointSpawnY1;
    public float pointSpawnX2;
    public float pointSpawnY2;

    private float timer = 0f;
    private int enemiesSpawned;

    public GameObject enemiesContainer; // ������������ ������ ��� ����������� ������

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timer += Time.deltaTime;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
        else if (playerObject == null)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy1 = Instantiate(enemyPrefab, new Vector2(pointSpawnX1, pointSpawnY2), Quaternion.identity);
        GameObject enemy2 = Instantiate(enemyPrefab, new Vector2(pointSpawnX2, pointSpawnY2), Quaternion.identity);
        enemiesSpawned++;

        // ������������� ������������ ������ ��� ��������� ������
        enemy1.transform.SetParent(enemiesContainer.transform);
        enemy2.transform.SetParent(enemiesContainer.transform);
    }
}