using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] float maxJumps = 2;
    [SerializeField] float jumps;
    [SerializeField] GameObject wall;
    [SerializeField] private float wallSlideSpeed = 2f;
    bool isTouchingWall = false;
    [SerializeField] private float wallJumpForce = 7f;
    [SerializeField] private float wallJumpHorizontalForce = 7f;


    private float horizontal;
    private bool groundCheck = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Handle jumping in Update()
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
            else if (isTouchingWall)
            {
                //float wallDirection = horizontal == 0 ? -Mathf.Sign(transform.localScale.x) : -Mathf.Sign(horizontal);
                //rb.AddForce(wallJumpHorizontalForce * wallDirection, wallJumpForce);
                //isTouchingWall = false;
            }
        }
    }
    private void FixedUpdate()
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


