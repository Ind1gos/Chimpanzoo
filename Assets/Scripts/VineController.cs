using UnityEngine;

public class VineController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform playerPos;
    [SerializeField] bool isAttached = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttached)
        {
            playerPos.position = this.transform.position;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isAttached = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerPos.position = other.transform.position;
            isAttached = true;
        }
    }
}
