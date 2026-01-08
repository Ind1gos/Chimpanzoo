using UnityEngine;
using UnityEngine.Animations;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D buttonCollider;
    [SerializeField] private GameObject buttonWall;
    public Animator buttonAnim;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        buttonCollider = GetComponent<CapsuleCollider2D>();

        buttonAnim = GetComponent<Animator>();

        bool isPressed = buttonAnim.GetBool("isPressed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Escort") && buttonCollider.isTrigger)
        {
            buttonAnim.SetBool("isPressed", true);
            buttonWall.SetActive(false);     
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escort"))
        {
            buttonAnim.SetBool("isPressed", false);
        }
    }
}
