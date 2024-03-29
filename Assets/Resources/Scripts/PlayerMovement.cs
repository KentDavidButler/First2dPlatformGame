﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public LayerMask whatIsGround;
    private float jump;
    private float maxFallSpeed = -4.5f;
    private Rigidbody2D playerRB;

    public bool isGrounded;
    

    private int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        extraJumps = 0;
        jump = 3;
    }

    private void FixedUpdate()
    {
        if(GetComponent<Rigidbody2D>().velocity.y < maxFallSpeed)
        {
            playerRB.velocity = new Vector2(0.0f, maxFallSpeed);
        }
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded == true && extraJumps > 0)
        {
            extraJumps = 0;
        }

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            
            if(isGrounded)
            {
                isGrounded = false;
                playerRB.velocity = Vector2.up * jump;
                extraJumps++;
            }
            else if(extraJumps == 0)
            {
                // this is so the player is able to jump once after walking off platform
                // without jumping prior.
                isGrounded = false;
                playerRB.velocity = Vector2.up * jump;
                extraJumps =+ 5;
            }
            else if(extraJumps == 1)
            {
                playerRB.velocity = Vector2.up * jump;
                extraJumps++;
            }
            else
            {
                //do nothing
                //can't make any more jumps
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isGrounded = true;
        }
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
