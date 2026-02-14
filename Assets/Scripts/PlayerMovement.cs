using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransfrom;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransfrom.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }
    public void Move(float direction, bool isJumpButtonPressed)
    {
            if(isJumpButtonPressed)
                Jump();

            if(Mathf.Abs(direction) > 0.01f)
                HorizontalMovement(direction);
    }
    private void Jump()
    {
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
        // curve.Evaluate(direction)
        // direction
        // Mathf.Abs(direction)
    }
}
