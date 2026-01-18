using NUnit.Framework;
using UnityEngine;

public class ButtonWallController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D wallCollider;
    public bool collideWithPlank = false;
    [SerializeField] ButtonWallController buttonWallController;


    

    ButtonController buttonController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //buttonController = GameObject.FindAnyObjectByType<ButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collideWithPlank)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

       

        //if (buttonController != null)
        //{
        //    foreach (GameObject wall in GameObject.FindGameObjectsWithTag("ButtonWall"))
        //    {
        //        wall.SetActive(!buttonController.pressingButton);
        //    }
        //}

        
        //if (buttonController.pressingButton)
        //{
        //    gameObject.SetActive(false);
        //}
        //else
        //{
        //    gameObject.SetActive(true);
        //}
        


    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Placed"))
        {
            collideWithPlank = true;
        }
        else
        {
            collideWithPlank = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("ButtonWall"))
    //    {
    //        collideWithPlank = true;
    //    }

    //    if(other.gameObject.CompareTag("Placed"))
    //    {
    //        collideWithPlank = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("ButtonWall"))
    //    {
    //        collideWithPlank = false;
    //    }

    //    if (other.gameObject.CompareTag("Placed"))
    //    {
    //        collideWithPlank = false;
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("ButtonWall"))
    //    {
    //        collideWithPlank = true;
    //    }
    //}

}
