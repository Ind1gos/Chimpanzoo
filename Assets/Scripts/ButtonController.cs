using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject buttonWall;
    private bool isPressed = false;
    public Animator buttonAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Panda"))
        {
            buttonAnim.Play("ButtonPush");
            if (!isPressed)
            {
                isPressed = true;
                buttonWall.SetActive(false);
            }
        }
    }
}
