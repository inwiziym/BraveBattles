using UnityEngine;
using System.Collections;

public class EnemyEasy : MonoBehaviour
{
    public float speed;
    public Animator Anim;
    float lastEnPosX = 0;
    bool lookLeft = true;
    bool isPlayerAnim = false;

    private void FixedUpdate()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform player = playerObject.GetComponent<Transform>();
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (lastEnPosX - transform.position.x > 0.03) lookLeft = true;
            if (lastEnPosX - transform.position.x < -0.03) lookLeft = false;

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
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            // игнорирование столкновения со слоем Coin
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerAnim = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerAnim = false;
        }
    }
}