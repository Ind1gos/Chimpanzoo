using UnityEngine;
using UnityEngine.Animations;

public class OscillatorButtonController : MonoBehaviour
{

    [SerializeField] private CapsuleCollider2D oscillatorbuttonCollider;

    public Animator buttonAnim;

    public bool pressingoscillatorButton = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oscillatorbuttonCollider = GetComponent<CapsuleCollider2D>();

        buttonAnim = GetComponent<Animator>();

        bool isPressed = buttonAnim.GetBool("isPressed");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Escort"))
        {
            Debug.Log("Oscillator Button Pressed");
            pressingoscillatorButton = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Oscillator Button Pressed");
            pressingoscillatorButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Escort"))
        {
            Debug.Log("Oscillator Button Exited");
            pressingoscillatorButton = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Oscillator Button Exited");
            pressingoscillatorButton = false;
        }
    }
}

