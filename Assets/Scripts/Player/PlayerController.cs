using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player; //публичная переменная чтобы в Unity Editor указать игрока
    public float speedPlayerY; //публичная переменная чтобы указать скорость игрока по оси Y

    private bool leftMove; //приватная переменная для активации движения влево
    private bool rightMove; //приватная переменная для активации движения вправо
    private Rigidbody2D rb;

    public int jumpforse;//публичная переменная для указания силы прыжка
    public int numberjumps; //публичная переменная для указания количество непрерывных прыжков
    private int countJump; //приватная перемення чтобы скрипт мог считать сколько доступно прыжков

    public Transform chekGround; //публичная переменная чтобы указать точку в игроке, когда должен соприкасаться с поверхностью
    public LayerMask whatGround; //публичная переменная, чтобы узанать что мы считаем за землю
    public float chekRadius; //публичная переменная, чтобы узнать радиус который мы будет проверять
    private bool isGround; //приватная переменная, чтобы определять соприкасается ли игрок с землей

    public Animator Anim; //публичная переменная чтобы указать анимацию

    private void Start() //приватная функция при запуске сцены
    {
        rb = GetComponent<Rigidbody2D>();

        Anim.SetBool("isRunning", false); //булевская переменная, которая отключает анимацию бега при старте : то есть по умолчанию проигрывается анимация IDLE
        leftMove = false; //при старте движение влево не активно
        rightMove = false; //при старте движение вправо не активно
        countJump = numberjumps; //при старке игрок получает доступное ему количество прыжков
    }

    private void Update() //фунция для обновления кадров со стороны телефона
    {
        if(isGround == true) //условие верное для соприкосновения игрока и земли
        {
            countJump = numberjumps; //игроку доступко количество доступных прыжков в реальном времени
        }
    }

    public void DownLeftMove() //публичная фунция движения влево, когда нажимается кнопка с компонентом Event Triggner
    {
        Anim.SetBool("isRunning", true); //булевская переменная, которая включает анимацию бега
        player.transform.localScale = new Vector3(-1f, 1f, 1f); //указывается в каком направлении будет игрок
        leftMove = true; //активация движения влево
    }

    public void UpLeftMove() //публичная фунция движения влево, когда отпускается кнопка с компонентом Event Triggner
    {
        Anim.SetBool("isRunning", false); //булевская переменная, которая отключает анимацию бега
        leftMove = false; //невозможно движения влево
    }

    public void DownRightMove() //публичная фунция движения вправо, когда нажимается кнопка с компонентом Event Triggner
    {
        Anim.SetBool("isRunning", true); //булевская переменная, которая включает анимацию бега
        player.transform.localScale = new Vector3(1f, 1f, 1f); //указывается в каком направлении будет игрок
        rightMove = true; //активация движения вправо
    }

    public void UpRightMove() //публичная фунция движения вправо, когда отпускается кнопка с компонентом Event Triggner
    {
        Anim.SetBool("isRunning", false); //булевская переменная, которая отключает анимацию бега
        rightMove = false; //невозможно движения влево
    }

    public void Jump()
    {
        countJump--; //отнимает доступное количество доступных прыжков
        if(countJump > 0) //если прыжков больше нуля то совершается функция прыжка
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

    private void FixedUpdate() //приватная функция Update
    {
        if (leftMove) //условие если активируется движение влево
        {
            player.transform.position += new Vector3(-speedPlayerY * Time.deltaTime, 0, 0); //происходит смена координат с помощью отрицания скорости
        }
        else if (rightMove) //условие если активируется движение вправо
        {
            player.transform.position += new Vector3(speedPlayerY * Time.deltaTime, 0, 0); //происходит смена координат с помощью скорости
        }
        isGround = Physics2D.OverlapCircle(chekGround.position, chekRadius, whatGround); //принятия точки, радиус вокрук точки, то что мы считаем за землю
    } 
}