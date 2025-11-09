using UnityEngine;
using System.Collections;

public class BambooController : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Transform bambooTransform;
    [SerializeField] GameObject squareObject;
    private Renderer squareRenderer;

    public bool isAttached = false;
    private bool hasBeenPickedUp = false;
    private Rigidbody2D rb; // Add a reference to Rigidbody2D

    [SerializeField] float throwForce = 10f; // You can adjust this in the Inspector

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

        if (squareObject != null)
        {
            squareRenderer = squareObject.GetComponent<Renderer>();
        }

        if (isAttached == true)
        {
            StartCoroutine(ToggleVisibility());
        }
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            if (squareRenderer != null)
            {
                squareRenderer.enabled = !squareRenderer.enabled;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (isAttached == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttached = false;
            ThrowBamboo();
        }
    }

    //private void ThrowBamboo()
    //{
    //    transform.SetParent(null, true);
    //    isAttached = false;

    //    // Calculate mouse position in world space
    //    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2 throwDirection = (mouseWorldPos - transform.position);


    //    if (rb != null)
    //    {
    //        rb.linearVelocity = Vector2.zero; // Reset velocity before throwing
    //        rb.AddForce(throwDirection.normalized * throwForce, ForceMode2D.Impulse);
    //    }
    //}

    private void ThrowBamboo()
    {
        // Släpp från handen
        transform.SetParent(null);
        isAttached = false;

        // Återaktivera fysik
        //rb.isKinematic = false;
        rb.simulated = true;

        // Räkna ut riktning mot muspekaren
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = (mouseWorldPos - transform.position);
        throwDirection.Normalize();

        // Nollställ och kasta
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasBeenPickedUp && other.gameObject.CompareTag("Player"))
        {
            SetParent();
            hasBeenPickedUp = true;
        }
    }

    public void SetParent()
    {
        if (hand != null)
        {
            transform.SetParent(hand, true);
            transform.localPosition = Vector3.zero;
            isAttached = true;
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; // Stop movement when picked up
            }
        }
        else
        {
            Debug.LogWarning("Hand transform is not assigned.");
        }
    }
}
