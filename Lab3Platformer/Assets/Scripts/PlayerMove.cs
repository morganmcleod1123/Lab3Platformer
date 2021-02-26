using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement Scripting Help - https://youtu.be/QGDeafTx5ug
// https://youtu.be/yB6ty0Gj7tA

public class PlayerMove : MonoBehaviour
{
    private GameManager gm;
    private Rigidbody2D rigidbody2D;
    Animator animator;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private int extraJumps;
    private float moveInput;
    private bool facingRight = true;

    public float dashDistance = 15f;
    bool isDashing;

    void Start()
    {
        gm = GameManager.Instance;
        extraJumps = gm.extraJumpVal;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontal", moveInput);
        animator.SetFloat("vertical", rigidbody2D.velocity.y);
        animator.SetBool("grounded", isGrounded);
        animator.SetBool("dashing", isDashing);

        if (isGrounded)
        {
            extraJumps = gm.extraJumpVal;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded) {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
        //Dash left
        if ((Input.GetKeyDown(KeyCode.LeftShift) && moveInput < 0) && gm.canDash)
        {
            StartCoroutine(Dash(-1f));
        }
        //Dash Right
        if((Input.GetKeyDown(KeyCode.LeftShift) && moveInput > 0) && gm.canDash)
        {
            StartCoroutine(Dash(1f));
        }
    }
    private void FixedUpdate()
    {
        if (!isDashing)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            moveInput = Input.GetAxisRaw("Horizontal");
            rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);
            if(!facingRight && moveInput > 0)
            {
                Flip();
            } else if(facingRight && moveInput < 0)
            {
                Flip();
            }
        } 
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    IEnumerator Dash(float direction)
    {
        isDashing = true;
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        rigidbody2D.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rigidbody2D.gravityScale = gravity;
    }
}
