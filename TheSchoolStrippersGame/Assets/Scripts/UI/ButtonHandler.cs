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

        //GameObject.Find("Dot1(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("Dot2(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("Dot3(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("Dot4(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;

        //GameObject.Find("DotPattern1(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern1(Clone)").transform.GetChild(1).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern2(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern2(Clone)").transform.GetChild(1).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern3(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern3(Clone)").transform.GetChild(1).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern4(Clone)").transform.GetChild(0).GetComponent<DotSpawnPoint>().enabled = false;
        //GameObject.Find("DotPattern4(Clone)").transform.GetChild(1).GetComponent<DotSpawnPoint>().enabled = false;
    }

    public void ContinueGame()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("DotSpawner").GetComponent<DotSpawner>().enabled = true;

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
