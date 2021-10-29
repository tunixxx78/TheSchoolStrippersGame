using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner, spawnPointForPowerUp;
    public GameObject arrow, obstacle, powerUpObject, powerUpImage;

    SFXManager sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        if (GameObject.Find("GreenDot(Clone)").GetComponent<MovingDots>().onBeatSpot)
        {
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }

        for (int i = 0; i < popUps.Length; i++)
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
        if (popUpIndex == 0)
        {
            if (GameObject.Find("GreenDot(Clone)").GetComponent<MovingDots>().onBeatSpot)
            {
                Time.timeScale = 0;
                arrow.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    arrow.SetActive(false);
                    Time.timeScale = 1;
                    popUpIndex++;
                    StartCoroutine(WaitTime());
                }
            }
        }
        else if (popUpIndex == 1)
        {
            StartCoroutine(nextPopUp());
            obstacle.SetActive(true);

            if (Time.timeScale == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Time.timeScale = 1;
                    popUpIndex++;
                    PowerUp();
                    StartCoroutine(WaitTime());
                }
            }
        }
        else if (popUpIndex == 2)  // Turo added for 4th sign.
        {
            obstacle.SetActive(false);
            powerUpImage.SetActive(false);
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;

                StartCoroutine(FinalPopUp());
            }

        }
        else if (popUpIndex == 3)
        {
            if (GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Combo>().attackCounter == 1)
            {
                arrow.SetActive(false);
                Time.timeScale = 0;
                spawner.SetActive(true);
                popUps[2].SetActive(false);

            }
        }
        

       IEnumerator nextPopUp()
        {
            
            yield return new WaitForSeconds(7f);
            popUpIndex = 2;
            PowerUp();


        }
        IEnumerator FinalPopUp() // Turo added for 4th sign.
        {
            
            yield return new WaitForSeconds(7f);
            popUpIndex = 3;
        }

        void PowerUp()
        {
            Instantiate(powerUpObject, spawnPointForPowerUp.transform.position, Quaternion.identity);
            sfx.ScreamingEagle();
            Destroy(spawnPointForPowerUp);
        }

        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
        }
    }



}
