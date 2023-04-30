using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector2 spawnPosition;

    void Start()
    {
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}
