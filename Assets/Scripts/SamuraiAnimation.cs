using UnityEngine;

public class SamuraiAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("isRunning", isRunning);
        
    //    if (moveInput != 0)
    //     {
    //         transform.localScale = new Vector3(
    //             Mathf.Sign(moveInput),
    //             transform.localScale.y,
    //             transform.localScale.z
    //         );
    //     }
        
        if (moveInput != 0)
        {
            transform.rotation = Quaternion.Euler(0, 
                moveInput > 0 ? 0 : 180,
                0);
        }

        if (Input.GetButtonDown("Fire1"))
            anim.SetBool("isShooting", true);
        if (Input.GetButtonUp("Fire1"))
            anim.SetBool("isShooting", false);
    }
}