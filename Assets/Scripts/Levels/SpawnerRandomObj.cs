using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandomObj : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ������ �������� �������� ��� ��������
    public float spawnDelay; // �������� ����� ��������� ��������
    private float timeSinceLastSpawn;

    public float minX; // ���������� � ����������� ������� �� ��� X
    public float maxX; // ���������� � ������������ �������� �� ��� X
    public float minY; // ���������� � ����������� ������� �� ��� Y
    public float maxY; // ���������� � ������������ �������� �� ��� Y

    void FixedUpdate()
    {
        // ����������� ����� � ������� ���������� �������� �������
        timeSinceLastSpawn += Time.deltaTime;

        // ���� ������ ���������� �������, ����� ������� ����� ������, ������� ���
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
