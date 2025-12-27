using Unity.VisualScripting;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public BambooController bambooController;
    [SerializeField] private GameObject bambooInstance;
    [SerializeField] private GameObject plankInstance;
    private float shootForce = 2.5f;
    [SerializeField] private GameObject bambooPrefab;
    [SerializeField] private Transform launchOffset;
    private bool isAimingRight;


    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private BoxCollider2D plankBoxCollider;
    [SerializeField] private Renderer plankRenderer;
    [SerializeField] private TMPro.TextMeshProUGUI Plankpile;
    [SerializeField] private Camera mainCam;
    Vector3 mousePos;
    Vector2 direction;

    public float maxPlanks = 5f;
    public float currentPlanks;

    private bool isPlacingPlank = false;

    public PandaController panda;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPlanks = maxPlanks;

        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - launchOffset.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        launchOffset.rotation = Quaternion.Euler(0f, 0f, rotZ).normalized;

        // Normalize to 0–360
        rotZ = Mathf.Repeat(rotZ + 360f, 360f);


        isAimingRight = rotZ <= 90.0f || rotZ >= 270.0f;

        if (isAimingRight)
        {
            transform.localPosition = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localPosition = new Vector3(-1, 1, 1);
        }

        //// BLOCK 89–91
        //if (rotZ > 89f && rotZ < 91f)
        //{
        //    // snap to the closer side
        //    rotZ = (rotZ < 90f) ? 89f : 91f;
        //}

        //// BLOCK 269–271
        //if (rotZ > 269f && rotZ < 271f)
        //{
        //    rotZ = (rotZ < 270f) ? 269f : 271f;
        //}

        direction = new Vector2(mousePos.x - launchOffset.position.x, mousePos.y - launchOffset.position.y);



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
        if (Input.GetKeyDown(KeyCode.R) && gameObject )
        {
            PlaceBlockR(gridPosition);
        }

        //Debug.Log(Equals(isAimingRight, true) ? "Aiming Right" : "Aiming Left");
        //Debug.Log("Rotation " + rotZ);

        //Plankpile.text = currentPlanks.ToString();


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
        //Gör vinkeln lättare för pandan att gå upp för plankan -> 45+90/2=67.5 -> funkar inte för att det är double -> 45+67.5/2=56.25 -> 56 -> märkte att det var fel håll så tar jag 56-45=11 -> 45-11=34 -> 34, fortfarande inte nog, gör den mindre, den klarade att gå upp för 2 så jag sänkte med en grad
        Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, -33));
        currentPlanks--;
    }
    void PlaceBlockE(Vector2 gridPosition)
    {
        Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, 33));
        currentPlanks--;
    }
    void PlaceBlockR(Vector2 gridPosition)
    {

        //bambooInstance = Instantiate(bambooPrefab, launchOffset.position, launchOffset.rotation);
        //Rigidbody2D rbBamboo = bambooInstance.GetComponent<Rigidbody2D>();

           
        plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.identity);

        //plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
        //plankRenderer = plankInstance.GetComponent<SpriteRenderer>();



        BoxCollider2D plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
        Renderer plankRenderer = plankInstance.GetComponent<Renderer>();

        if (plankBoxCollider != null)
        {
            plankBoxCollider.enabled = false;

            Color color = plankRenderer.material.color;
            color.a = 0.5f;
            plankRenderer.material.color = color;

        }





        currentPlanks--;
    }
}
