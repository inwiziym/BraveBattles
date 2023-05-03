using Photon.Pun;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    public GameObject player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPositin = new Vector2(Random.Range(minY, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(player.name, randomPositin, Quaternion.identity);
    }
}
