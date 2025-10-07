using UnityEngine;

public class BambooController : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Transform bambooTransform;
    public bool isAttached = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetParent();
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
        else if(isAttached == false)
        {
            transform.SetParent(null, true);
        }
    }
}
