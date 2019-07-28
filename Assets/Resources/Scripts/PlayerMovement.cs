using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    private float jump;
    private float maxFallSpeed = 3.0f;
    private float xVelocity = 0.0f;
    private CapsuleCollider2D groundedCollider;
    private Rigidbody2D playerRB;

    public bool isGrounded;
    public LayerMask whatIsGround;

    public int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
        groundedCollider = GetComponent<CapsuleCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        extraJumps = 0;
        //jump = 35;
        jump = 3;
    }

    private void FixedUpdate()
    {
        if(GetComponent<Rigidbody2D>().velocity.y > maxFallSpeed)
        {
            //xVelocity = GetComponent<Rigidbody2D>().velocity.Set(GetComponent<Rigidbody2D>().velocity.x;
            //GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.Set( xVelocity, maxFallSpeed);
            //playerRB.velocity = Vector2.ClampMagnitude(playerRB.velocity, maxFallSpeed);
            //Debug.Log(playerRB.velocity + "Velocity blah blah");
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
            //jump = 3;
        }

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            
            if(isGrounded)
            {
                isGrounded = false;
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse); //trying new form of jumping using velocity
                playerRB.velocity = Vector2.up * jump;
                extraJumps++;
            }
            else if(extraJumps == 1)
            {
                //jump = 2;
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                playerRB.velocity = Vector2.up * jump;
                extraJumps++;
            }
            else
            {
                //do nothing
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
}
