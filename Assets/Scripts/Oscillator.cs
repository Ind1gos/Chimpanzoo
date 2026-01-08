using UnityEngine;
using Physics = UnityEngine.Physics2D;
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] Vector3 lastPosition;
    [SerializeField] float period = 2f;
    [SerializeField] Transform oscillatorTransform;

    [SerializeField] bool collideWithPlank = false;

    float elapsedTime = 0f;

    float movementFactor;
    Vector3 startingPosition;

    public OscillatorButtonController oscillatorbuttonController;

    void Start()
    {
        
        startingPosition = transform.position;
    }

    void Update()
    {
        //if (period <= Mathf.Epsilon)
        //{
        //    return;
        //}

        //if (oscillatorbuttonController.pressingoscillatorButton == false)
        //{
        //    elapsedTime += Time.deltaTime;
        //}

        //if(oscillatorbuttonController.pressingoscillatorButton == true)
        //{
        //    elapsedTime ; // Hold the elapsed time constant when button is pressed
        //}

        //float cycles = Time.time / period; // continually growing over time

        //const float tau = Mathf.PI * 2; // constant value of 6.283
        //float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        //movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

        //Vector3 offset = movementVector * movementFactor;
        //transform.position = startingPosition + offset;




        if (oscillatorbuttonController.pressingoscillatorButton == false)
        {
            float cycles = Time.time / period; // continually growing over time

            const float tau = Mathf.PI * 2; // constant value of 6.283
            float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

            movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;

            lastPosition = transform.position;
        }
        if (oscillatorbuttonController.pressingoscillatorButton == true || collideWithPlank == true) // pressingoscillatorButton == true
        {
            // Stop oscillator movement by keeping current position
            gameObject.transform.position = lastPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Placed"))
        {
            collideWithPlank = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Placed"))
        {
            collideWithPlank = false;
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
