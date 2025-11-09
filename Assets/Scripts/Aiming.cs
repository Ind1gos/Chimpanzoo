using UnityEngine;

public class Aiming : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player;
    public float orbitRadius = 1.5f;
    public Rigidbody2D playerRB;

    [Header("Fire Points and Prefabs")]
    public Transform firePoint;
    public GameObject bambooPrefab;

    [SerializeField] Camera mainCamera;

    private void Update()
    {
        OrbitAroundPlayer();
        AimAtMouse();
        Shoot();    
    }
    private void OrbitAroundPlayer()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
        mousePosition.z = 0f;

        Vector3 direction = (mousePosition - player.position).normalized;
        transform.position = player.position + direction * orbitRadius;
    }

    private void AimAtMouse()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
        mousePosition.z = 0f;

        Vector3 aimDirection = (mousePosition - firePoint.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, angle);
        if ((mousePosition.x < player.position.x && player.localScale.x > 0) ||
            (mousePosition.x > player.position.x && player.localScale.x < 0))
        {
            player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
        }
    }
    private void Shoot()
    {
        Instantiate(bambooPrefab, firePoint.position, firePoint.rotation);
    }
}
