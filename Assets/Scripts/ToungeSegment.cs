using System.Diagnostics;
using UnityEngine;

public class ToungeSegment : MonoBehaviour
{
    public int index;
    public SnakeController snakeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Placed"))
        {
            snakeController.DisableSegment(index);
        }



        //snakeController.DisableSegment(index);




        //GameObject hitObject = other.gameObject;
        //Debug.Log("Tounge Segment Collided with: " + hitObject.name);
        //int hitIndex = snakeController.segments.IndexOf(hitObject);
        //if (hitIndex != -1 && hitIndex < index)
        //{
        //    Debug.Log("Tounge Segment " + index + " collided with segment " + hitIndex);
        //    // Additional logic for handling the collision can be added here
        //}
    }


    //private void OnCollisionExit2D(Collision2D other)
    //{

    //    if (other.gameObject.CompareTag("Placed"))
    //    {
    //        snakeController.EnableSegment(index);
    //    }


    //}
    //Ändra så den är trigger i snakecontroller
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Placed"))
        {
            snakeController.EnableSegment(index);
        }
    }

}
