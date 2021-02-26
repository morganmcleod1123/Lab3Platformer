using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    SpriteRenderer sr;
    Animator animator;


    float horizontal;
    float vertical;
    public float runSpeed = 10f;
    public float dashSpeed = 10f;
    public float jumpForce = 10f;
    public int jumpCountMax = 2;
    private int jumpCountCurrent;

    private bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("horizontal", horizontal);
        
        

        if (horizontal < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        if (Input.GetKeyDown("space") && jumpCountCurrent > 0)
        {
            Jump();
        }
        if (Input.GetKeyDown("left shift")) {
            Dash();
        }
        
    }

    private void FixedUpdate()
    {
        if (!dashing)
        {
            body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
        }
        else {
            StartCoroutine("TurnOffDashing");
            StopCoroutine("TurnOffDashing");
        }
    }
    IEnumerator TurnOffDashing()
    {
        yield return new WaitForSeconds(0.1f);
        dashing = false;
    }
    private void Jump()
    {
        Debug.Log("Jump");
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        jumpCountCurrent--;

    }
    private void Dash()
    {
        dashing = true;
        body.velocity = new Vector2(horizontal *  dashSpeed, vertical *  dashSpeed);
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCountCurrent = jumpCountMax;
        }
    }
}
