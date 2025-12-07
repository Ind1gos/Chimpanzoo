using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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
    bool isHoldingBamboo = true;
    
    

    private GameObject currentBamboo;
    GameObject bambooInstance;
    [SerializeField] private Transform launchOffset;
    


    [SerializeField] GameObject blockPrefab;

    [SerializeField] Camera mainCam;
    //private bool jumpInput;

    public float horizontal;
    private bool groundCheck = false;


    Vector3 mousePos;
    Vector2 mouseWorld;
    Vector2 relativeMouse;
    Vector2 direction;

    BambooController BambooController;
    public PandaController panda;

    //Input system

    private void Awake()
    {

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;

        if (mainCam == null)
        {
            mainCam = Camera.main;
        }

    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        

        //Wall jump
        if (CompareTag("Wall") && Input.GetKeyDown(KeyCode.Space))
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

        //Flip sprite (använder för Wall Jump)  lägg till när behöver den 
        ////if (horizontal < 0)
        ////{
        ////    transform.localScale = new Vector3(1, 1, 1);
        ////}
        ////else if (horizontal > 0)
        ////{
        ////    transform.localScale = new Vector3(-1, 1, 1);
        ////}

        


        //Fire bamboo
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (bambooPrefab != null && launchOffset != null)
        //    {
        //        Instantiate(bambooPrefab, launchOffset.position, launchOffset.rotation);
        //    }
        //}

        ////if (Input.GetButtonDown("Fire1"))
        ////{
        ////    GameObject bambooInstance = Instantiate(bambooPrefab, launchOffset.position, launchOffset.rotation);
        ////    Rigidbody2D rbBamboo = bambooInstance.GetComponent<Rigidbody2D>();
        ////    rbBamboo.linearVelocity = new Vector2(transform.localScale.x * 5f, 0); // example horizontal launch speed
        ////}




        // Rotate launch offset toward mouse


        ////if (mousePos.x < transform.position.x)
        ////{
        ////    transform.localScale = new Vector3(-1, 1, 1);
        ////}
        ////else
        ////{
        ////    transform.localScale = new Vector3(1, 1, 1);
        ////}

        //mousePos = (mainCam.ScreenToWorldPoint(Input.mousePosition));

        //Vector3 rotation = mousePos - launchOffset.position;

        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //launchOffset.rotation = Quaternion.Euler(0f, 0f, rotZ);

        //    // Rotate launchOffset toward mouse
        //    Vector2 aimDir = (mouseWorld - launchOffset.position);
        //    float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        //    launchOffset.rotation = Quaternion.Euler(0, 0, angle);

        //    // Update crosshair position
        //    if (crosshair != null)
        //        crosshair.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, 0);

        //    // Fire bamboo
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        ShootBamboo(aimDir.normalized);
        //    }
        //}

        //private void ShootBamboo(Vector2 direction)
        //{
        //    if (bambooPrefab == null || launchOffset == null)
        //    {
        //        Debug.LogError("Missing bambooPrefab or launchOffset reference.");
        //        return;
        //    }

        //    GameObject bamboo = Instantiate(bambooPrefab, launchOffset.position, launchOffset.rotation);
        //    Rigidbody2D rbBamboo = bamboo.GetComponent<Rigidbody2D>();

        //    if (rbBamboo != null)
        //    {
        //        rbBamboo.AddForce(direction * shootForce, ForceMode2D.Impulse);
        //    }

        //}

        //if (isHoldingBamboo)
        //{
        //    //Left
        //    if (horizontal < 0)
        //    {
        //        bambooController.MoveLeft();
        //    }
        //    //Right
        //    else if (horizontal > 0)
        //    {
        //        bambooController.MoveRight();
        //    }
        //}






        ////mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        ////Vector3 rotation = mousePos - launchOffset.position;

        ////float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        ////launchOffset.rotation = Quaternion.Euler(0f, 0f, rotZ);

        // Flip sprite if mouse is left/right of player


        // Fire bamboo toward mouse









        //new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

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


