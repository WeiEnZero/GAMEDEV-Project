using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverUI;
    //public GameObject EnemySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        GameOverUI.SetActive(true);
        //EnemySpawner.SetActive(false);
    }

    public void restart()
    {
        Debug.Log("test");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClick()
    {
        Debug.Log("test");
        restart();
    }
}
