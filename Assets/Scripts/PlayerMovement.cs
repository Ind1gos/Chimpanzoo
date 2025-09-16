using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] float jumps;
    [SerializeField] float maxJumps = 2;
    [SerializeField] float wallJumps;
    [SerializeField] float maxWallJumps = 1;
    [SerializeField] GameObject wall;
    [SerializeField] private float wallSlideSpeed = 2f;
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

        //Hopp från mark 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumps--;
                Debug.Log(jumps);
            }
            //double jump
            else if (jumps > 0)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumps--;
                Debug.Log(jumps);
            }
            //Hopp från vägg
            if (isTouchingWall && wallJumps > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                jumps = 0;
                if (horizontal < 0)
                {
                    rb.AddForce(new Vector2(1, 1 * jumpForce));
                    wallJumps--;
                }
                else if (horizontal > 0)
                {
                    rb.AddForce(new Vector2(-1, 1 * jumpForce));
                    wallJumps--;
                }
            }
        }
        //Flip sprite (använder för Wall Jump)
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
            wallJumps = maxWallJumps;
            Debug.Log(wallJumps);
        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            jumps = 0;
            Debug.Log("Wall");
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
        if (other.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = true;

            // If player is moving down and touching wall, apply wall slide
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
            }
        }
    }


}


