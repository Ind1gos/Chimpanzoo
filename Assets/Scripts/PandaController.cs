using Unity.VisualScripting;
using UnityEngine;

public class PandaController : MonoBehaviour
{
    public float speed = 10f; // The speed at which the object moves
    
    public AimController aimController;
    public Transform target;


    private void Start()
    {

    }
    void Update()
    {
        // Ensure there is a target and it's not null
        if (target != null)
        {
            //// Get the current position of this GameObject
            //Vector2 currentPosition = transform.position;

            //// Get the target position
            //Vector2 targetPosition = bambooInstance.transform.position;

            // Move towards the target position
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.position) < 0.4f)
            {
                speed = 0;
            }
            else if (Vector2.Distance(transform.position, target.position) >= 0.5f)
            {
                speed = 5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bamboo"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oscillator"))
        { 
           transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oscillator"))
        {
            transform.SetParent(null);
        }
    }
}

