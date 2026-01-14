using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] PlankController plankController;
    [SerializeField] private TextMeshProUGUI plankText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private TextMeshProUGUI bananaText;



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
        Debug.Log(plankText.text);

        bananaText.text = playerMovement.BananaCount.ToString();
        Debug.Log(bananaText.text);
    }
}
