using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D buttonCollider;
    [SerializeField] private GameObject buttonWall;
    public Animator buttonAnim;
    LayerMask buttonwallLayer;

    public bool pressingButton = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonCollider = GetComponent<CapsuleCollider2D>();

        buttonAnim = GetComponent<Animator>();

        bool isPressed = buttonAnim.GetBool("isPressed");

        buttonwallLayer = LayerMask.GetMask("ButtonWall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Escort"))
    //    {
    //        buttonAnim.SetBool("isPressed", true);
    //        //buttonWall.SetActive(false);     

    //        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
    //        {
    //            Debug.Log("Deactivating Button Walls");
    //            wall.SetActive(false);
    //        }
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Escort"))
    //    {
    //        buttonAnim.SetBool("isPressed", false);
    //        //buttonWall.SetActive(true);

    //        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
    //        {
    //            Debug.Log("Activating Button Walls");
    //            wall.SetActive(true);
    //        }
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Escort"))
    //    {
    //        pressingButton = true;

    //        buttonAnim.SetBool("isPressed", true);
    //        //buttonWall.SetActive(false);
    //        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
    //        {
    //            Debug.Log("Deactivating Button Walls");
    //            wall.SetActive(false);
    //        }
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escort"))
        {
            pressingButton = true;


            //buttonAnim.SetBool("isPressed", true);
            ////buttonWall.SetActive(false);
            //foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
            //{
            //    Debug.Log("Deactivating Button Walls");
            //    wall.SetActive(false);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Escort"))
         {
            pressingButton = false;


            //buttonAnim.SetBool("isPressed", false);
            // //buttonWall.SetActive(true);
            // foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
            // {
            //     Debug.Log("Activating Button Walls");
            //     wall.SetActive(true);
            // }
         }

            




    }
        
}  



