using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    SpriteRenderer sr;


    float horizontal;
    public float runSpeed = 5f;
    public float jumpForce = 400f;

    private bool jumping;
   // private bool grounded;

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
        if (Input.GetKeyDown("space") && !jumping)
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
        body.AddForce(new Vector2(0f, jumpForce));
        jumping = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
    IEnumerator Jump2()
    {
        float timePassed = 0f;
        while(timePassed < 0.5f)
        {
            timePassed += Time.deltaTime;
            Debug.Log("I have been jumping for " + timePassed + " seconds!");
            yield return null;
        }    
    }
    
}
