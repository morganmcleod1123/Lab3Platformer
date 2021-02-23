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
    public int jumpCountMax = 2;
    private int jumpCountCurrent;

    private bool jumping;

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
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        //jumping = true;
        jumpCountCurrent--;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jumping = false;
        jumpCountCurrent = jumpCountMax;
    }
}
