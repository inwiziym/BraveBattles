using UnityEngine;

public class EnemyEasy : MonoBehaviour
{
    public Transform player;
    public float speed;

    public Animator Anim;

    float lastEnPosX = 0;
    bool lookLeft = true;
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (lastEnPosX - transform.position.x > 0.01) lookLeft = true;
        if (lastEnPosX - transform.position.x < -0.01) lookLeft = false;

        if (lookLeft)
            transform.localScale = new Vector3(-1f, 1f, 1f); // лево
        else
            transform.localScale = new Vector3(1f, 1f, 1f); // право
        lastEnPosX = transform.position.x;
    }
    float time = 0;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && time <= 0)
        {
            Anim.SetTrigger("isAttackArm");
            time = 1;
        }
        time -= Time.deltaTime;
    }
}
