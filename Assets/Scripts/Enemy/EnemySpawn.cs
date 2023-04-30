using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // префаб врага
    public float spawnInterval; // интервал спавна врагов
    public float pointSpawnX1;
    public float pointSpawnY1;

    public float pointSpawnX2;
    public float pointSpawnY2;

    public int maxEnemyScene;

    private float timer = 0f;
    private int enemiesSpawned = 0; // количество созданных врагов



    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timer += Time.deltaTime;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null && timer >= spawnInterval && enemiesSpawned < maxEnemyScene) // проверяем наличие объекта "Player" и количество созданных врагов
        {
            SpawnEnemy();
            timer = 0f;
        }
        else if (playerObject == null) // Если объект "Player" не найден, уничтожаем текущий объект
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(pointSpawnX1, pointSpawnY2), Quaternion.identity);
        //Instantiate(enemyPrefab, new Vector2(pointSpawnX2, pointSpawnY2), Quaternion.identity);
        enemiesSpawned++; // увеличиваем счетчик созданных врагов
    }
}