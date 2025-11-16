using UnityEngine;

public class PandaController : MonoBehaviour
{

    [SerializeField] Transform target;
    public float speed = 5f; // The speed at which the object moves
    

    private void Start()
    {
        
    }
    void Update()
    {
        // Ensure there is a target and it's not null
        if (target != null && target.tag == ("ThrownBamboo"))
        {
            // Get the current position of this GameObject
            Vector2 currentPosition = transform.position;

            // Get the target position
            Vector2 targetPosition = target.transform.position;

            // Move towards the target position
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}

