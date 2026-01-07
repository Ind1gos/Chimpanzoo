using UnityEngine;
using Physics = UnityEngine.Physics2D;
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    Vector3 lastPosition;
    [SerializeField] float period = 2f;

    float movementFactor;
    Vector3 startingPosition;

    public ButtonController buttonController;

    void Start()
    {
        
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        if(buttonController != null)
        {
            if (buttonController.pressingoscillatorButton == false)
            {
                float cycles = Time.time / period; // continually growing over time

                const float tau = Mathf.PI * 2; // constant value of 6.283
                float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

                movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

                Vector3 offset = movementVector * movementFactor;
                transform.position = startingPosition + offset;

                lastPosition = transform.position;
            }
            else // pressingoscillatorButton == true
            {
                // Stop oscillator movement by keeping current position
                transform.position = lastPosition;
            }
        }
        

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
    //    if (rb != null)
    //    {
    //       Physics.autoSyncTransforms = true;
    //    }
    //    else
    //    {
    //        Physics.autoSyncTransforms = false;
    //    }
    //}

}
