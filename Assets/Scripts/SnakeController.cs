using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.HableCurve;

public class SnakeController : MonoBehaviour
{

    RaycastHit2D hit;



    //[SerializeField] List<GameObject> segments;

    public List<GameObject> segments;

    GameObject hitObject;

    // Update is called once per frame
    void Update()
    {
        //hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, (LayerMask.GetMask("Ground") || LayerMask.GetMask("Placed") || LayerMask.GetMask("ButtonWall") || LayerMask.GetMask("Oscillator"));
        hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground", "Placed", "ButtonWall", "Oscillator"));
        //Debug.Log("hit.collider.tag");





        //foreach(GameObject segment in segments)
        //{
            
        //}

        //switch (currentCollisions)
        //{
        //    case :
        //        Debug.Log("Colliding with: " + hit.collider.name);
        //        break;
        //    case false:
        //        Debug.Log("Not colliding with anything.");
        //        break;
        //    }



            //foreach (Collider2D col in currentCollisions)
            //{
            //    if (col.CompareTag("Wall") || col.CompareTag("Ground") || col.CompareTag("ButtonWall") || col.CompareTag("Oscillator") || col.CompareTag("Placed"))
            //    {
            //        Debug.Log("Colliding with wall: " + col.name);
            //    }
            //}


    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    GameObject hitObject = other.gameObject;
    //    Debug.Log("Collided with: " + hitObject.name);

    //    int hitIndex = segments.IndexOf(hitObject);

    //    if (hitIndex >= 0)
    //    {
    //        DestroyFromIndex(hitIndex);
    //        Debug.Log("Snake segment destroyed from index: " + hitIndex);
    //    }
    //}

    //void DestroyFromIndex(int index)
    //{
    //    for (int i = segments.Count - 1; i >= index; i--)
    //    {
    //        Destroy(segments[i]);
    //        segments.RemoveAt(i);
    //    }
    //}

    public void DisableSegment(int index)
    {
        //BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = index; i < segments.Count; i++)
        {

            //segments[i].SetActive(false);

            segments[i].GetComponent<BoxCollider2D>().isTrigger = true;
            segments[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        //if (index >= 0 && index < segments.Count)
        //{
        //    DestroyFromIndex(index);
        //    Debug.Log("Snake segment disabled from index: " + index);
        //}
    }
    public void EnableSegment(int index)
    {
        for (int i = index; i < segments.Count; i++)
        {
            //segments[i].SetActive(true);

            segments[i].GetComponent<BoxCollider2D>().isTrigger = false;
            segments[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
