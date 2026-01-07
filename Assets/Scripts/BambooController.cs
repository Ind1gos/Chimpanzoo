using UnityEngine;
using System.Collections;

public class BambooController : MonoBehaviour
{
    //[SerializeField] Camera mainCam;
    PlayerMovement horizontal;
    public Rigidbody2D rbBamboo;

    Vector3 mousePos;
    private void Awake()
    {
        rbBamboo = GetComponent<Rigidbody2D>();
        //mainCam = GetComponent<Camera>();
    }
    private void Update()
    {
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = new Vector2
        //(
        //    mousePos.x - transform.position.x,
        //    mousePos.y - transform.position.y
        //);
        //direction.Normalize();
        //float rotateAmount = Vector3.Cross(direction, transform.right).z;
        //bambooRB.angularVelocity = -rotateAmount * speed;
    }
    //public void MoveLeft()
    //{
    //    transform.Translate(Vector2.left * speed * Time.deltaTime);
    //}
    //public void MoveRight()
    //{
    //    transform.Translate(Vector2.right * speed * Time.deltaTime);
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oscillator"))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oscillator"))
        {
            transform.SetParent(null);
        }
    }
}