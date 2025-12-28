using Unity.VisualScripting;
using UnityEngine;

public class PandaController : MonoBehaviour
{
    public float speed = 10f; // The speed at which the object moves
    
    public PlayerMovement bambooInstance;
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

            if (Vector2.Distance(transform.position, target.position) < 0.25f)
            {
                speed = 0;
            }
            else if (Vector2.Distance(transform.position, target.position) >= 0.25f)
            {
                speed = 5f;
            }
        }

    }
    
}

