using System.Collections.Generic;
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
    public int pickedupPlanks;
    [SerializeField] List<GameObject> placedPlanks;
    [SerializeField] GameObject plankPlaced;



    Camera plankCamera;

    AimController aimController;
    [SerializeField] PlankManager plankManager;




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

        //FÖRSTA, TAR BARA BORT SENASTE PLANKAN
        if (plankInstance != null && Input.GetKeyDown(KeyCode.F) && Vector2.Distance(mouseposPlank, plankInstance.transform.position) < plankmouseDistance)
        {
            OnEnterIdle();
        }

        //foreach (var placedPlank in placedPlanks)
        //{
        //    if (plankInstance != null && Input.GetKeyDown(KeyCode.F) && Vector2.Distance(mouseposPlank, placedPlank.transform.position) < plankmouseDistance)
        //    {
        //        plankInstance = placedPlank;
        //        OnEnterIdle();
        //        break; // Remove this if you want to allow multiple pickups per frame
        //    }
        //}

        //if (plankInstance != null && Input.GetKeyDown(KeyCode.F) && Vector2.Distance(mouseposPlank, plankInstance.transform.position) < plankmouseDistance)
        //{
        //    OnEnterIdle();
        //}

        //LOOPAR IGENOM ALLA PLANKOR I LISTAN
        //if (Input.GetKeyDown(KeyCode.F) && plankManager != null && plankManager.PlacedPlanks != null)
        //{
        //    foreach (var placedPlank in placedPlanks)
        //    {
        //        if (placedPlank != null && Vector2.Distance(mouseposPlank, placedPlank.transform.position) < plankmouseDistance)
        //        {
        //            // Optionally, you can set plankInstance = placedPlank if you want to operate on it
        //            plankInstance = placedPlank;
        //            OnEnterIdle();
        //            break; // Remove this if you want to allow multiple pickups per frame
        //        }
        //    }
        //}


        //TA BORT PLANKA MED TAG INTE PLANKINSTANCE
        //if (plankInstance != null && Input.GetKeyDown(KeyCode.F) && Vector2.Distance(mouseposPlank, plankPlaced.transform.position) < plankmouseDistance)
        //{
        //    OnEnterIdle();
        //}




        //if (plankInstance == null && Input.GetKeyDown(KeyCode.R))
        //{
        //    OnEnterPreview(gridPosition);
        //}

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            OnEnterPreview(gridPosition);
        }

        if (plankInstance != null && Input.GetMouseButtonDown(1) && plankInstance.CompareTag("Preview") && pickedupPlanks > 0)
        {
            OnEnterPlaced();
            Debug.Log("Plank Placed");
        }


        if (plankInstance != null && plankInstance.tag == "Preview")
        {
            plankInstance.transform.position = gridPosition;


            if(Input.GetKey(KeyCode.E))
            {
                plankInstance.transform.Rotate(0f, 0f, 5f);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                plankInstance.transform.Rotate(0f, 0f, -5f);
            }


            //placedPlanks = GameObject.FindGameObjectsWithTag("Placed");

            //gör till en lista av alla plankor med taggen "Placed"
            placedPlanks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Placed"));



            //if(plankInstance != null && plankInstance.tag == "Placed")
            //{
            //    plankPlaced = placedPlanks[0];

            //    plankInstance = plankPlaced;
            //}

            
        }

        


        if (plankInstance == null)
        {
            Debug.Log("No GameObject called exampleGameObject found");
        }
        else
        {
            Debug.Log("PlankInstance not null");
        }

        Debug.Log(pickedupPlanks);
    }

    void OnEnterIdle()
    {
        if(plankInstance == null)
        {
            Destroy(plankInstance);
            plankInstance = null;
        }
        else if(plankInstance != null && plankInstance.tag == "Placed")
        {
            //plankManager.UnregisterPlacedPlank(plankInstance);
            pickedupPlanks += 1;
            
            Destroy(plankInstance);
            plankInstance = null;
        }
        //plankInstance.SetActive(false);



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
        //plankInstance.layer = LayerMask.NameToLayer("PlacedPlank");
        //plankManager.RegisterPlacedPlank(plankInstance);

        pickedupPlanks -= 1;

        plankBoxCollider.enabled = true;
        Color color = plankRenderer.material.color;
        color.a = 1f;
        plankRenderer.material.color = color;

    }

    //public List<GameObject> GetAll()
    //{
    //    return placedPlanks;
    //}


}
