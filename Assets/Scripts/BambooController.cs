using UnityEngine;
using System.Collections;

public class BambooController : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Transform bambooTransform;
    [SerializeField] GameObject squareObject;
    private Renderer squareRenderer;

    public bool isAttached = false;
    private bool isPickedUp = false;

    private void Start()
    {
        // If not assigned in Inspector, try to get the Renderer from this GameObject
        if(squareObject != null)
        squareRenderer = squareObject.GetComponent<Renderer>();
        
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
                squareRenderer.enabled = !squareRenderer.enabled;
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if(isAttached == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.SetParent(null, true);
            isAttached = false;
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isPickedUp && other.gameObject.CompareTag("Player"))
        {
            SetParent();
            isPickedUp = true;
        }
    }

    public void SetParent()
    {
        if (hand != null)
        {
            transform.SetParent(hand, true);
            transform.localPosition = Vector3.zero;
            isAttached = true;
        }
        else
        {
            Debug.LogWarning("Hand transform is not assigned.");
        }
    }

}
