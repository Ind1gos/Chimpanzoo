using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] float wallJumpForce;
    [SerializeField] float wallSlideSpeed;

    float jumps;
    float maxJumps = 2;
    float wallJumps;
    float maxWallJumps = 1;
    bool isTouchingWall = false;


    private float horizontal;
    private bool groundCheck = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;
        wallJumps = maxWallJumps;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumps--;
                Debug.Log(jumps);
            }
            //Double jump
            else if (jumps > 0)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumps--;
                Debug.Log(jumps);
            }
            //Wall jump

            if (isTouchingWall && Input.GetKeyDown(KeyCode.Space))
            {
                if (horizontal < 0)
                {
                    rb.AddForce(new Vector2(1, 1) * wallJumpForce);
                    jumps--;
                }
                else if (horizontal > 0)
                {
                    rb.AddForce(new Vector2(-1, 1) * wallJumpForce);
                    jumps--;
                }
                //S� inte mer �n 1 jump logic h�nder samtidigt
                return;
            }
        }
        //Flip sprite (anv�nder f�r Wall Jump)
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
    }
    void FixedUpdate()
    {
        // Apply movement without overriding jump
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;

            jumps = maxJumps;
            Debug.Log(jumps);
            //wallJumps = maxWallJumps;
            //Debug.Log(wallJumps);
        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log(jumps);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //wall slide
        if (other.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = true;
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
            }
        }
    }


}


