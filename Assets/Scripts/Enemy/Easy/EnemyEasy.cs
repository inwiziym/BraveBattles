using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyEasy : MonoBehaviour
{
    public float speed;
    public Animator Anim;
    float lastEnPosX = 0;
    bool lookLeft = true;
    bool isPlayerAnim = false;

    float exitPlayerTime = 0f;
    bool canMove = true;
    private void FixedUpdate()
    {
        if (!canMove) return;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform player = playerObject.GetComponent<Transform>();
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (lastEnPosX - transform.position.x > 0.02) lookLeft = true;
            if (lastEnPosX - transform.position.x < -0.02) lookLeft = false;

            if (lookLeft)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                transform.localScale = new Vector3(1f, 1f, 1f);
            lastEnPosX = transform.position.x;

            Anim.SetBool("isAttackArm", isPlayerAnim);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerAnim = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerAnim = true;
            exitPlayerTime = Time.time;
            canMove = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerAnim = false;
        }
    }
    public void Update()
    {
        if (!canMove && Time.time - exitPlayerTime >= 0.5f)
        {
            canMove = true;
        }
    }
}