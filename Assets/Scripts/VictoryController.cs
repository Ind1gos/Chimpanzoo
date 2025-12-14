using UnityEngine;

public class VictoryController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Player") && CompareTag("Escort"))
        {
            Debug.Log("Victory!");
        }
    }
}
