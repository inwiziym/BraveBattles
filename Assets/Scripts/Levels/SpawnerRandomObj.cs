using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandomObj : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // массив префабов объектов для создания
    public float spawnDelay; // задержка между созданием объектов
    private float timeSinceLastSpawn;

    public float minX; // переменная с минимальная позиции по оси X
    public float maxX; // переменная с максимальной позицией по оси X
    public float minY; // переменная с минимальная позиции по оси Y
    public float maxY; // переменная с максимальной позицией по оси Y

    void FixedUpdate()
    {
        // Увеличиваем время с момента последнего создания объекта
        timeSinceLastSpawn += Time.deltaTime;

        // Если прошло достаточно времени, чтобы создать новый объект, создаем его
        if (timeSinceLastSpawn >= spawnDelay)
        {
            float RandX = Random.Range(minX, maxX);
            float RandY = Random.Range(minY, maxY);
            int randIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randIndex];
            Instantiate(objectToSpawn, new Vector3(RandX, RandY, transform.position.z), transform.rotation);
            timeSinceLastSpawn = 0f;
        }
    }
}
