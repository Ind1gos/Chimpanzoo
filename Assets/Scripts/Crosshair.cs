using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float orbitRadius = 10f;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        OrbitAroundPlayer();
    }

    private void OrbitAroundPlayer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePosition.z = 0f;

        Vector3 direction = (mousePosition - player.position).normalized;
        transform.position = player.position + direction * orbitRadius;
    }
}
