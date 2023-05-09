using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedObjX;
    public float speedObjY;
    internal Vector2 direction;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speedObjX, transform.position.y + speedObjY, transform.position.z);
    }
}
