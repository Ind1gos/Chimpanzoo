using UnityEngine;

public class LilypadController : MonoBehaviour
{
    [SerializeField] float lilypadVelocity = -0.1f;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Rigidbody2D lilypadrb;
    [SerializeField] bool collidingwithPlayer = false;
 
    Transform LilypadTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lilypadrb.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (collidingwithPlayer)
        {
            lilypadrb.linearVelocity = Vector2.zero; // Stop the lilypad when the player steps off
        }
    }

    void OnCollision2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && lilypadrb != null)
        {
            collidingwithPlayer = true;
        }
    }
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player") && (lilypadrb != null))
    //    {
    //        lilypadrb.linearVelocity = new Vector2(0, lilypadVelocity);

    //    }
    //lilypadrb.constraints = RigidbodyConstraints2D.None;
    //else
    //{
    //    collidingwithPlayer = false;
    //    lilypadrb.linearVelocity = new Vector2(0, -lilypadVelocity);
    //    //lilypadrb.constraints = RigidbodyConstraints2D.FreezePositionY;
    //}
    //}



}
