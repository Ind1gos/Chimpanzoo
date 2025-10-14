using UnityEngine;

public class BambooController : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Transform bambooTransform;

    public bool isAttached = false;
    private bool isPickedUp = false;

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
