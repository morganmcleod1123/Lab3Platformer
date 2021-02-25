using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    SpriteRenderer sr;


    float horizontal;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float dashForce = 1500f;
    public int jumpCountMax = 2;
    private int jumpCountCurrent;

    //private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
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
        if(Input.GetKeyDown("left shift"))
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
    }
    private void Jump()
    {
        Debug.Log("Jump");
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        //jumping = true;
        jumpCountCurrent--;

    }
    private void Dash()
    {
        Debug.Log("You hit left shift");
        //body.velocity = new Vector2(400f, body.velocity.y);
        body.AddForce(new Vector2(dashForce, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //jumping = false;
            jumpCountCurrent = jumpCountMax;
        }
    }
}
