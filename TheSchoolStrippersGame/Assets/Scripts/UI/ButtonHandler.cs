using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelection");
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
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("DotSpawner").GetComponent<DotSpawner>().enabled = false;
        GameObject.Find("CollectingDotsSpawner").GetComponent<DotSpawner>().enabled = false;

        //GameObject.Find("BlueDot(Clone)").GetComponent<MovingDots>().enabled = false;
        //GameObject.Find("YellowDot(Clone)").GetComponent<MovingDots>().enabled = false;
        //GameObject.Find("RedDot(Clone)").GetComponent<MovingDots>().enabled = false;
        //GameObject.Find("GreenDot(Clone)").GetComponent<MovingDots>().enabled = false;
    }

    public void ContinueGame()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("DotSpawner").GetComponent<DotSpawner>().enabled = true;
        GameObject.Find("CollectingDotsSpawner").GetComponent<DotSpawner>().enabled = true;

        //GameObject.FindGameObjectWithTag("BlueDot").GetComponent<MovingDots>().enabled = true;
        //GameObject.FindGameObjectWithTag("YellowDot").GetComponent<MovingDots>().enabled = true;
        //GameObject.FindGameObjectWithTag("RedDot").GetComponent<MovingDots>().enabled = true;
        //GameObject.FindGameObjectWithTag("GreenDot").GetComponent<MovingDots>().enabled = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
