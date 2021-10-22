using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public SFXManager sounds;

    private void Start()
    {
        sounds = FindObjectOfType<SFXManager>();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("PopUps").transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void PlayButton()
    {
        Invoke("NowReallyPlay", 0.5f);

        Time.timeScale = 1;
        sounds.ButtonPress();
    }

    public void PlayButtonForTutorial()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    private void NowReallyPlay()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void TryAgainButton()
    {
        FindObjectOfType<ScoringSystem>().SetPointsToZero();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sounds.ButtonPress();

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        sounds.ButtonPress();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        sounds.ButtonPress();
    }
    public void NextLevel()
    {
        Invoke("NowNextLevel", 1f);
        sounds.ButtonPress();
    }
    private void NowNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        sounds.ButtonPress();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        sounds.ButtonPress();
    }

    public void StartLevelOne()
    {
        FindObjectOfType<ScoringSystem>().SetPointsToZero();
        SceneManager.LoadScene("Level1");
        sounds.ButtonPress();
    }

    public void PlayButtonSound()
    {
        sounds.ButtonPress();
    }
}
