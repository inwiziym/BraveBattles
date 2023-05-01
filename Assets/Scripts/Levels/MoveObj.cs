using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float speedObjX;
    public float speedObjY;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speedObjX, transform.position.y + speedObjY, transform.position.z);
    }
}
