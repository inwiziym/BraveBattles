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

    public int maxEnemyScene;

    private float timer = 0f;
    private int enemiesSpawned = 0; // ���������� ��������� ������



    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timer += Time.deltaTime;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null && timer >= spawnInterval && enemiesSpawned < maxEnemyScene) // ��������� ������� ������� "Player" � ���������� ��������� ������
        {
            SpawnEnemy();
            timer = 0f;
        }
        else if (playerObject == null) // ���� ������ "Player" �� ������, ���������� ������� ������
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(pointSpawnX1, pointSpawnY2), Quaternion.identity);
        //Instantiate(enemyPrefab, new Vector2(pointSpawnX2, pointSpawnY2), Quaternion.identity);
        enemiesSpawned++; // ����������� ������� ��������� ������
    }
}