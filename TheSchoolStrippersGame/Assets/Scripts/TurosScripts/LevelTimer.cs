using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 10f;
    bool timerIsRuning = false;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject gameOverText, player, smokeyPanel;


    private void Start()
    {
        timerIsRuning = true;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (timerIsRuning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                player.SetActive(false);
                gameOverText.SetActive(true);
                smokeyPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (timeRemaining < 20f)
        {
            timerText.color = Color.red;
            timerText.fontSize = 25;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

}
