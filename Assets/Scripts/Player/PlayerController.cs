using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player; //��������� ���������� ����� � Unity Editor ������� ������
    public float speedPlayerY; //��������� ���������� ����� ������� �������� ������ �� ��� Y

    private bool leftMove; //��������� ���������� ��� ��������� �������� �����
    private bool rightMove; //��������� ���������� ��� ��������� �������� ������
    private Rigidbody2D rb;

    public int jumpforse;//��������� ���������� ��� �������� ���� ������
    public int numberjumps; //��������� ���������� ��� �������� ���������� ����������� �������
    private int countJump; //��������� ��������� ����� ������ ��� ������� ������� �������� �������

    public Transform chekGround; //��������� ���������� ����� ������� ����� � ������, ����� ������ ������������� � ������������
    public LayerMask whatGround; //��������� ����������, ����� ������� ��� �� ������� �� �����
    public float chekRadius; //��������� ����������, ����� ������ ������ ������� �� ����� ���������
    private bool isGround; //��������� ����������, ����� ���������� ������������� �� ����� � ������

    public Animator Anim; //��������� ���������� ����� ������� ��������

    private void Start() //��������� ������� ��� ������� �����
    {
        rb = GetComponent<Rigidbody2D>();

        Anim.SetBool("isRunning", false); //��������� ����������, ������� ��������� �������� ���� ��� ������ : �� ���� �� ��������� ������������� �������� IDLE
        leftMove = false; //��� ������ �������� ����� �� �������
        rightMove = false; //��� ������ �������� ������ �� �������
        countJump = numberjumps; //��� ������ ����� �������� ��������� ��� ���������� �������
    }

    private void Update() //������ ��� ���������� ������ �� ������� ��������
    {
        if(isGround == true) //������� ������ ��� ��������������� ������ � �����
        {
            countJump = numberjumps; //������ �������� ���������� ��������� ������� � �������� �������
        }
    }

    public void DownLeftMove() //��������� ������ �������� �����, ����� ���������� ������ � ����������� Event Triggner
    {
        Anim.SetBool("isRunning", true); //��������� ����������, ������� �������� �������� ����
        player.transform.localScale = new Vector3(-1f, 1f, 1f); //����������� � ����� ����������� ����� �����
        leftMove = true; //��������� �������� �����
    }

    public void UpLeftMove() //��������� ������ �������� �����, ����� ����������� ������ � ����������� Event Triggner
    {
        Anim.SetBool("isRunning", false); //��������� ����������, ������� ��������� �������� ����
        leftMove = false; //���������� �������� �����
    }

    public void DownRightMove() //��������� ������ �������� ������, ����� ���������� ������ � ����������� Event Triggner
    {
        Anim.SetBool("isRunning", true); //��������� ����������, ������� �������� �������� ����
        player.transform.localScale = new Vector3(1f, 1f, 1f); //����������� � ����� ����������� ����� �����
        rightMove = true; //��������� �������� ������
    }

    public void UpRightMove() //��������� ������ �������� ������, ����� ����������� ������ � ����������� Event Triggner
    {
        Anim.SetBool("isRunning", false); //��������� ����������, ������� ��������� �������� ����
        rightMove = false; //���������� �������� �����
    }

    public void Jump()
    {
        countJump--; //�������� ��������� ���������� ��������� �������
        if(countJump > 0) //���� ������� ������ ���� �� ����������� ������� ������
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforse);
        }
        else if (countJump == 0 && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforse);
        }
    }

    public void PlayAttack()
    {
        Anim.SetTrigger("PlayAttack");
    }

    private void FixedUpdate() //��������� ������� Update
    {
        if (leftMove) //������� ���� ������������ �������� �����
        {
            player.transform.position += new Vector3(-speedPlayerY * Time.deltaTime, 0, 0); //���������� ����� ��������� � ������� ��������� ��������
        }
        else if (rightMove) //������� ���� ������������ �������� ������
        {
            player.transform.position += new Vector3(speedPlayerY * Time.deltaTime, 0, 0); //���������� ����� ��������� � ������� ��������
        }
        isGround = Physics2D.OverlapCircle(chekGround.position, chekRadius, whatGround); //�������� �����, ������ ������ �����, �� ��� �� ������� �� �����
    } 
}