using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    [SerializeField] float trampolineForce = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(Vector2.up * trampolineForce, ForceMode2D.Impulse);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
