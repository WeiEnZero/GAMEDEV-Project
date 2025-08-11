using Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject GamePauseUI;
    Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            GamePauseUI.SetActive(true);
            Time.timeScale = 0f;
        } 


    }

    public void gameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("enemy"); // Gets an array of GameObjects in the game that has the Tag "enemy" currently in the running game 
        foreach (GameObject obj in objectsToDestroy)      // For the Game Objects in the Array, all the "enemy" tagged game objects will be destroyed
        {
            Destroy(obj);
        }

    }

    public void OnExit()
    {
        ExitGame();
    }

    public void ResumeGame()
    {
        GamePauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Loads the Active Scene that is currently in the Unity Build according to the first index
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit(); // Exits the game entirely.
    }

    public void OnClick()
    {
        restart();     // The On Click function contains the restart function and used when the player clicks the restart button on the Game Over Menu and it would reload the active scene
    }
}
