using UnityEngine;

public class AimController : MonoBehaviour
{
    public BambooController bambooController;
    GameObject bambooInstance;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private GameObject bambooPrefab;
    [SerializeField] private Transform launchOffset;

    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Camera mainCam;
    Vector3 mousePos;
    Vector2 direction;

    public PandaController panda;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - launchOffset.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        launchOffset.rotation = Quaternion.Euler(0f, 0f, rotZ);

        direction = new Vector2(mousePos.x - launchOffset.position.x, mousePos.y - launchOffset.position.y).normalized;


        if (mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ThrowBamboo();
        }

        Vector2 gridPosition = Vector2Int.RoundToInt(mousePos);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceBlockQ(gridPosition);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceBlockE(gridPosition);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlaceBlockR(gridPosition);
        }



        

        Debug.DrawLine(launchOffset.position, mousePos, Color.red);
    }

    void ThrowBamboo()
    {
        //(mousePos - launchOffset.position).normalized;
        //direction = new Vector2((mousePos.x - launchOffset.position.x), (mousePos.y - launchOffset.position.y)).normalized;

        //Vector3 direction = mousePos - launchOffset.position;


        bambooInstance = Instantiate(bambooPrefab, launchOffset.position, launchOffset.rotation);
        Rigidbody2D rbBamboo = bambooInstance.GetComponent<Rigidbody2D>();

        if (rbBamboo != null)
        {
            rbBamboo.AddForce(direction * shootForce, ForceMode2D.Impulse);
        }

        panda.target = rbBamboo.transform;
    }
    void PlaceBlockQ(Vector2 gridPosition)
    {
        Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, 45));
    }
    void PlaceBlockE(Vector2 gridPosition)
    {
        Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, -45));
    }
    void PlaceBlockR(Vector2 gridPosition)
    {
        Instantiate(blockPrefab, gridPosition, Quaternion.identity);
    }
}
