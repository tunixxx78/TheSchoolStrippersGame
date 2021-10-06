using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            if(GameObject.Find("GreenDot(Clone)").GetComponent<MovingDots>().onBeatSpot)
            {
                Debug.Log("On kohdalla"); 
                Time.timeScale = 0;
                if (Input.GetMouseButton(0))
                {
                    Time.timeScale = 1;
                    popUpIndex++;
                }
            }
        }
        else if (popUpIndex == 1)
        {
            Debug.Log("Toka pop up");
            if (Input.GetKeyDown(KeyCode.K))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            Debug.Log("Kolmas pop up");
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 0;
                spawner.SetActive(true);
            }
        }

    }
}
