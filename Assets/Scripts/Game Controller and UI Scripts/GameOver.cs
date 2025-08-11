using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Text timeText;
    Timer timer;

    public void Setup(string timeremianing)
    {
        timeText.text = $"You survived for {timeremianing}";
    }
}
