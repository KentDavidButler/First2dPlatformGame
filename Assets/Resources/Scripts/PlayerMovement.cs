using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    private float jump;
    private CapsuleCollider2D groundedCollider;

    public bool isGrounded;
    public LayerMask whatIsGround;

    public int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
        groundedCollider = GetComponent<CapsuleCollider2D>();
        extraJumps = 0;
        jump = 35;
    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //isGrounded = Physics2D.IsTouchingLayers(groundCheck, whatIsGround);
        //isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.01f, 0.05f), 0, 0);
        //isGrounded = groundedCollider.IsTouchingLayers(8);
        //isGrounded = groundedCollider.isTrigger;
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded == true && extraJumps > 0)
        {
            extraJumps = 0;
            jump = 35;
        }

        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetBool("IsGrounded", isGrounded);

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            
            if(isGrounded)
            {
                isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                extraJumps++;
            }
            else if(extraJumps == 1)
            {
                jump = 25;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
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
