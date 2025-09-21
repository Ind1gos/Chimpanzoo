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
    bool isTouchingWall = false;
    //private bool jumpInput;


    private float horizontal;
    private bool groundCheck = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //Wall jump
        if (isTouchingWall && Input.GetKeyDown(KeyCode.Space))
        {
            if (horizontal < 0)
            {                                                //alla hopp lika starka
                rb.AddForce(new Vector2(1, 1) * wallJumpForce);
                jumps--;
            }
            else if (horizontal > 0)
            {
                rb.AddForce(new Vector2(-1, 1) * wallJumpForce);
                jumps--;
            }
            return;
            //Så inte mer än 1 jump logic händer samtidigt

        }

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
            return;
        }

        //Flip sprite (använder för Wall Jump)
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jumpInput = true;
        //}
    }
    void FixedUpdate()
    {
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


