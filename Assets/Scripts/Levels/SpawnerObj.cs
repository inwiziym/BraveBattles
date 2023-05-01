using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObj : MonoBehaviour
{
    public float posX;
    public float posY;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawnerObject")
        {
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
