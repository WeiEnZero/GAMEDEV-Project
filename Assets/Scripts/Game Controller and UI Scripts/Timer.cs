using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    //public GameObject Hero;
    public GameOver gameOver;
    public GameObject GameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeIsRunning = true; //Initiates the start of the countdown to be true when the game start
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)    // Since the time running is true, the timer would keep on increasing every second with Time.deltaTime and the DisplayTime function will display the timer on the game screen.
        {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if (GameOverUI) {
            gameOver.Setup(timeText.text);
        }
    }
}
