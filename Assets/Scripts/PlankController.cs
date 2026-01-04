using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlankController : MonoBehaviour
{
    [SerializeField] GameObject plankPrefab;
    private GameObject plankInstance;
    private Quaternion currentRotation;
    [SerializeField] private BoxCollider2D plankBoxCollider;
    [SerializeField] private Renderer plankRenderer;
    [SerializeField] private Transform plankTransform;
    Vector2 gridPosition;
    [SerializeField] Vector2 mouseposPlank;

    

    AimController aimController;
    Camera plankCamera; 


    float plankmouseDistance = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimController = GetComponent<AimController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aimController != null && aimController.MainCamera != null)
        {
            mouseposPlank = aimController.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            return;
        }


        if (mouseposPlank == null) return;


        gridPosition = Vector2Int.RoundToInt(aimController.MainCamera.ScreenToWorldPoint(Input.mousePosition));


        if (plankInstance != null && Input.GetKeyDown(KeyCode.F) && Vector2.Distance(mouseposPlank, plankInstance.transform.position) < plankmouseDistance)
        {
            OnEnterIdle();
        }


        //if (plankInstance == null && Input.GetKeyDown(KeyCode.R))
        //{
        //    OnEnterPreview(gridPosition);
        //}

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            OnEnterPreview(gridPosition);
        }
        if (plankInstance != null && Input.GetMouseButtonDown(1) && plankInstance.CompareTag("Preview"))
        {
            OnEnterPlaced();
        }

       

        if (plankInstance != null && plankInstance.tag == "Preview")
        {
            plankInstance.transform.position = gridPosition;


            if(Input.GetKeyDown(KeyCode.E))
            {
                plankInstance.transform.Rotate(0f, 0f, 10f);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                plankInstance.transform.Rotate(0f, 0f, -10f);
            }
        }



        if (plankInstance == null)
        {
            Debug.Log("No GameObject called exampleGameObject found");
        }
        else
        {
            Debug.Log("PlankInstance not null");
        }


    }

    void OnEnterIdle()
    {
        //plankInstance.SetActive(false);
        Destroy(plankInstance);
        plankInstance = null;
    }
    
    void OnEnterPreview(Vector2 gridPosition)
    {
        if(plankInstance == null  ||  plankInstance.tag == ("Placed"))
        {
            plankInstance = Instantiate(plankPrefab, gridPosition, Quaternion.identity);

            Debug.Log("PlankInstance created");

            plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
            plankRenderer = plankInstance.GetComponent<Renderer>();


            plankInstance.tag = "Preview";

            plankBoxCollider.enabled = false;
            Color color = plankRenderer.material.color;
            color.a = 0.5f;
            plankRenderer.material.color = color;
        } 
    }

    void OnEnterPlaced() 
    {
        plankInstance.tag = "Placed";

        plankBoxCollider.enabled = true;
        Color color = plankRenderer.material.color;
        color.a = 1f;
        plankRenderer.material.color = color;

    }


    

}
