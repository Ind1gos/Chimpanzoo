using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlankpileController : MonoBehaviour
{

    AimController aimController;

    private float currentPlanks;

    [SerializeField] TMP_Text plankText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plankText.enabled = true;

        currentPlanks = aimController.currentPlanks;


    }

    // Update is called once per frame
    void Update()
    {
        plankText.text = currentPlanks.ToString();

        if (CompareTag("Player"))
        {
            aimController.currentPlanks = aimController.maxPlanks;

            Debug.Log("Plankpile Refilled!");
        }
    }
}
