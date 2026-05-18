using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed = 1f; 
    [SerializeField] private float DashSpeed = 10f; 
    [SerializeField] private float TimeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    
    private Rigidbody2D rb;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState, currentTimeToRevert;
    private float currentSpeed; 
    private int direction = -1; 

    // Логика случайного рывка
    private int turnsCounter = 0;      // Счетчик обычных разворотов
    private int targetTurnsToDash;     // Сколько разворотов нужно сделать до рывка

    void Start()
    {
        currentSpeed = Speed; 
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
        
        // Генерируем первое случайное число (2 или 3)
        if(gameObject)
        ChooseNextDashCycle();
    }

    void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }

        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;

            case WALK_STATE:
                rb.velocity = new Vector2(direction * currentSpeed, rb.velocity.y);
                break;

            case REVERT_STATE:
                sp.flipX = !sp.flipX;
                direction *= -1; 

                turnsCounter++; // Засчитываем этот разворот

                // Проверяем, наступил ли момент для рывка
                if (turnsCounter >= targetTurnsToDash)
                {
                    currentSpeed = DashSpeed;   // Включаем скорость 10
                    turnsCounter = 0;          // Сбрасываем счетчик
                    ChooseNextDashCycle();     // Выбираем новую цель (2 или 3)
                }
                else
                {
                    currentSpeed = Speed;       // Иначе идем с обычной скоростью 1
                }

                currentState = WALK_STATE;
                break;
        }
        
        anim.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        { 
            currentState = IDLE_STATE;
            rb.velocity = Vector2.zero;
        } 
    }

    // Метод случайного выбора: 2 или 3 цикла до следующего рывка
    private void ChooseNextDashCycle()
    {
        // Random.Range для int не включает верхнюю границу, поэтому (2, 4) выдаст только 2 или 3
        targetTurnsToDash = Random.Range(2, 4); 
    }
}
