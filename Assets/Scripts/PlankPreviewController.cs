using UnityEngine;

public class PlankPreviewController : MonoBehaviour
{
    //[SerializeField] private GameObject plankInstance;
    
    //[SerializeField] private GameObject blockPrefab;
    //[SerializeField] private BoxCollider2D plankBoxCollider;
    //[SerializeField] private Renderer plankRenderer;
    //[SerializeField] private TMPro.TextMeshProUGUI Plankpile;
    //[SerializeField] private Camera mainCam;

    //Vector2 gridPosition;

    //public float maxPlanks = 5f;
    //public float currentPlanks;

    ////private bool isPlacingPlank = true;
    //private bool isPlacingPlankQ = true;
    //private bool isPlacingPlankE = true;
    //private bool isPlacingPlankR = true;

    ////[SerializeField] private PlankType currentPlankType;
    ////[SerializeField] private PlankState currentPlankState;

    //private enum PlankState
    //{
    //    NONE,
    //    PREVIEW,
    //    PLACED
    //}

    //private PlankState state;

    //void Start()
    //{
    //    currentPlanks = maxPlanks;
    //}

    //void Update()
    //{
    //    //Vector2 gridPosition = Vector2Int.RoundToInt(mousePos);

    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if (isPlacingPlankQ == false && Input.GetKeyDown(KeyCode.Q))
    //        {
    //            PlaceBlockQ(gridPosition);
    //            isPlacingPlankQ = true;
    //        }
    //        else if (isPlacingPlankQ == true && Input.GetKeyDown(KeyCode.Q))
    //        {
    //            PlaceBlockQ(gridPosition);

    //            isPlacingPlankQ = false;
    //        }
    //    }  

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //       if (isPlacingPlankE == false && Input.GetKeyDown(KeyCode.E))
    //       {
    //           PlaceBlockE(gridPosition);
    //           isPlacingPlankE = true;
    //       }
    //       else if (isPlacingPlankE == true && Input.GetKeyDown(KeyCode.E))
    //       {
    //           PlaceBlockE(gridPosition);
    //           isPlacingPlankE = false;
    //       }
    //    }

    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        if (isPlacingPlankR == false && Input.GetKeyDown(KeyCode.R) && gameObject)
    //        {
    //            PlaceBlockR(gridPosition);
    //            isPlacingPlankR = true;
    //        }
    //        else if (isPlacingPlankR == true && Input.GetKeyDown(KeyCode.R) && gameObject)
    //        {
    //            PlaceBlockR(gridPosition);
    //            isPlacingPlankR = false;
    //        }
    //    }


    //    if (isPlacingPlankQ == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }

    //    if (isPlacingPlankE == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }

    //    if (isPlacingPlankR == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }
        


    //        //if (isPlacingPlankR == false && Input.GetKeyDown(KeyCode.R) && gameObject)
    //        //{
    //        //    PlaceBlockR(gridPosition);
    //        //    isPlacingPlank = true;
    //        //    isPlacingPlankR = true;
    //        //}
    //        //else if (isPlacingPlank == true && Input.GetKeyDown(KeyCode.R) && gameObject)
    //        //else if (isPlacingPlankR == true && Input.GetKeyDown(KeyCode.R) && gameObject)
    //        //        {
    //        //            PlaceBlockR(gridPosition);
    //        //            isPlacingPlank = false;
    //        //            isPlacingPlankR = false;
    //        //        }

            
    //    if (isPlacingPlankQ == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }

    //    if (isPlacingPlankE == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }

    //    if (isPlacingPlankR == false && plankInstance != null)
    //    {
    //        //gridPosition = Vector2Int.RoundToInt(mousePos);
    //        plankInstance.transform.position = gridPosition;
    //    }

    //    Debug.Log("isPlacingPlankR: " + isPlacingPlankR);
        
        
    //}

    ////public GameObject getPlankInstance() { return plankInstance; }
    //void PlaceBlockQ(Vector2 gridPosition)
    //{
    //    isPlacingPlankQ = !isPlacingPlankQ;

    //    plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, -33));

    //    plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
    //    Renderer plankRenderer = plankInstance.GetComponent<Renderer>();

    //    if (plankInstance != null && isPlacingPlankQ == false)
    //    {
    //        plankBoxCollider.enabled = false;
    //        Color color = plankRenderer.material.color;
    //        color.a = 0.5f;
    //        plankRenderer.material.color = color;
    //    }
    //    else if (plankInstance != null && isPlacingPlankQ == true)
    //    {
    //        plankBoxCollider.enabled = true;
    //        Color color = plankRenderer.material.color;
    //        color.a = 1f;
    //        plankRenderer.material.color = color;
    //    }

    //    currentPlanks--;
    //    return;
    //}



    //void PlaceBlockE(Vector2 gridPosition)
    //{
    //    isPlacingPlankE = !isPlacingPlankE;

    //    plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, 33));

    //    BoxCollider2D plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
    //    Renderer plankRenderer = plankInstance.GetComponent<Renderer>();

    //    if (plankInstance != null && isPlacingPlankE == false)
    //    {
    //        plankBoxCollider.enabled = false;
    //        Color color = plankRenderer.material.color;
    //        color.a = 0.5f;
    //        plankRenderer.material.color = color;
    //    }
    //    else if (plankInstance != null && isPlacingPlankE == true)
    //    {
    //        plankBoxCollider.enabled = true;
    //        Color color = plankRenderer.material.color;
    //        color.a = 1f;
    //        plankRenderer.material.color = color;
    //    }

    //    currentPlanks--;
    //    return;
    //}

    //void PlaceBlockR(Vector2 gridPosition)
    //{
    //    isPlacingPlankR = !isPlacingPlankR;

    //    plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, 33));

    //    BoxCollider2D plankBoxCollider = plankInstance.GetComponent<BoxCollider2D>();
    //    Renderer plankRenderer = plankInstance.GetComponent<Renderer>();

    //    if (plankInstance != null && isPlacingPlankE == false)
    //    {
    //        plankBoxCollider.enabled = false;
    //        Color color = plankRenderer.material.color;
    //        color.a = 0.5f;
    //        plankRenderer.material.color = color;
    //    }
    //    else if (plankInstance != null && isPlacingPlankE == true)
    //    {
    //        plankBoxCollider.enabled = true;
    //        Color color = plankRenderer.material.color;
    //        color.a = 1f;
    //        plankRenderer.material.color = color;
    //    }

    //    currentPlanks--;
    //    return;
    //}

    ////void PlaceBlock(Vector2 gridPosition)
    ////{
    ////    switch (currentPlankType)
    ////    {
    ////        case PlankType.Q:
    ////            plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, -33));
    ////            break;

    ////        case PlankType.E:
    ////            plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.Euler(0, 0, 33));
    ////            break;

    ////        case PlankType.R:
    ////            plankInstance = Instantiate(blockPrefab, gridPosition, Quaternion.identity);
    ////            break;
    ////    }
    ////}
}

