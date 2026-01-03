using System;
using UnityEngine;
using UnityEngine.Rendering;

public enum BuildMode
{
    NONE,
    ONGOING,
    PLACED
}

public class BuildModeController : MonoBehaviour
{
    public BuildMode currentMode;

    public event Action<BuildMode> OnBuildModeChanged;

    public PlankPreviewController previewController;
    
    
    


    void Start()
    {
        previewController = GetComponent<PlankPreviewController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //CheckPlankState(plankInstance, plankBoxCollider);
        }


        //if(plankpreviewController != null)
        //{
        //    switch (currentMode)
        //    {
        //        case BuildMode.NONE:
        //            // Handle NONE mode
        //            break;
        //        case BuildMode.ONGOING:
        //            // Handle ONGOING mode
        //            break;
        //        case BuildMode.PLACED:
        //            // Handle PLACED mode
        //            break;
        //    }
        //}
    }

    //void CheckPlankState(PlankPreviewController previewController)
    //{
        

    //    if (previewController.getPlankInstance() == null)
    //    {
    //        currentMode = BuildMode.NONE;
    //        return;
    //    }
    //    else if ((plankInstance != null) && (plankInstance.GetComponent<BoxCollider2D>().enabled == false))
    //    {
    //        currentMode = BuildMode.ONGOING;
    //        return;
    //    }
    //    else if (plankInstance != null && previewController.plankBoxCollider.enabled == true)
    //    {
    //        currentMode = BuildMode.PLACED;
    //        return;
    //    }
    //}
    
}
