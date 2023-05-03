using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class multyControllerPlayer : MonoBehaviour
{
    PhotonView photonView;
    public GameObject player;
    public float speedPlayerY;

    private bool leftMove;
    private bool rightMove;
    private Rigidbody2D rb;

    public int jumpforse;
    public int numberjumps;
    private int countJump;

    public Transform chekGround;
    public LayerMask whatGround;
    public float chekRadius;
    private bool isGround;

    public Animator Anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("isRunning", false);
        leftMove = false;
        rightMove = false;
        countJump = numberjumps;

        if (photonView.IsMine) // Проверяем, является ли этот объект управляемым игроком текущего игрока
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z); // Позиционируем камеру на текущем игроке
        }
    }
    [PunRPC]
    public void SetPlayerVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
    private void Update()
    {
        if (photonView.IsMine) // Проверяем, является ли этот объект управляемым игроком текущего игрока
        {
            if (isGround == true)
            {
                countJump = numberjumps;
            }

            if (leftMove == true)
            {
                photonView.RPC("SetPlayerVelocity", RpcTarget.All, new Vector2(-speedPlayerY, rb.velocity.y)); // Вызываем RPC метод для установки скорости игрока влево
            }

            if (rightMove == true)
            {
                photonView.RPC("SetPlayerVelocity", RpcTarget.All, new Vector2(speedPlayerY, rb.velocity.y)); // Вызываем RPC метод для установки скорости игрока вправо
            }
        }
    }

    public void DownLeftMove()
    {
        Anim.SetBool("isRunning", true);
        player.transform.localScale = new Vector3(-1f, 1f, 1f);
        leftMove = true;
    }

    public void UpLeftMove()
    {
        Anim.SetBool("isRunning", false);
        leftMove = false;
        photonView.RPC("SetPlayerVelocity", RpcTarget.All, new Vector2(0, rb.velocity.y)); // Вызываем RPC метод для остановки игрока влево
    }

    public void DownRightMove()
    {
        Anim.SetBool("isRunning", true);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        rightMove = true;
    }

    public void UpRightMove()
    {
        Anim.SetBool("isRunning", false);
        rightMove = false;
        photonView.RPC("SetPlayerVelocity", RpcTarget.All, new Vector2(0, rb.velocity.y)); // Вызываем RPC метод для остановки игрока вправо
    }

    public void Jump()
    {
        countJump--;
        if (countJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforse);
        }
    }

}
