using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] bool playerVictory = false;
    [SerializeField] bool escortVictory = false;
    [SerializeField] GameObject victoryScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerVictory && escortVictory)
        {
            victoryScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerVictory = true;
            Debug.Log("Player In Victory Zone!");
        }
        if (other.gameObject.CompareTag("Escort"))
        {
            escortVictory = true;
            Debug.Log("Escort In Victory Zone!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerVictory = false;
            Debug.Log("Player Left Victory Zone!");
        }
        if (collision.gameObject.CompareTag("Escort"))
        {
            escortVictory = false;
            Debug.Log("Escort Left Victory Zone!");
        }
    }
}


