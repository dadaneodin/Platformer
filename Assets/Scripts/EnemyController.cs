using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed, TimeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    private Rigidbody2D rb;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState, currentTimeToRevert;


    void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch(currentState)
        {
            case IDLE_STATE:
                break;
            case WALK_STATE:
                break;
            case REVERT_STATE:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyStopper"))
            currentState = IDLE_STATE;
    }
}
