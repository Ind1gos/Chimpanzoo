using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public VictoryController victoryController;
    public PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        if (playerMovement.player != null && playerMovement.player.transform.parent != null)
        {
            playerMovement.player.transform.SetParent(null);
        }

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);

        if (currentScene.buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            ShowVictoryScreen();


            //Debug.Log("No more scenes to load. Restarting from first scene.");
           /* SceneManager.LoadScene(0);*/ // Restart from the first scene if no more scenes are available
        }
        Debug.Log("Loading Next Scene: " + (currentScene.buildIndex + 1));
    }

    private void ShowVictoryScreen()
    {
        if (victoryController != null)
        {
            victoryController.ShowVictoryScene();
        }
        else
        {
            Debug.LogWarning("VictoryController reference is not set in RespawnController.");
        }
    }
}
