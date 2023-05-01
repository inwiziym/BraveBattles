using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objSpawner;

    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;


    public float delay;

    void Start()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }
    void SpawnObject()
    {
        GameObject objectToSpawn = objSpawner[Random.Range(0, objSpawner.Length)];
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);
        Instantiate(objectToSpawn, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }

    IEnumerator SpawnObjectWithDelay()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(delay);
        }
    }
}
