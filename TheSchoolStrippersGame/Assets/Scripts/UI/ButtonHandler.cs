using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("PopUps").transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
}
