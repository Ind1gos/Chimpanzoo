using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] PlankController plankController;
    [SerializeField] private TextMeshProUGUI plankText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //plankText.enabled = true;
        
        //currentPlanks = aimController.currentPlanks;


    }

    // Update is called once per frame
    void Update()
    {
        plankText.text = plankController.pickedupPlanks.ToString();
        Debug.Log("Plank UI Updated!");
    }
}
