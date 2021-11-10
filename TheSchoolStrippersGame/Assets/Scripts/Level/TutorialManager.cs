using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner, spawnPointForPowerUp;
    public GameObject arrow, obstacle, powerUpObject, powerUpImage, uDotsInGame;

    SFXManager sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    void Update()
    {

        /*if (GameObject.Find("GreenDot(Clone)").GetComponent<MovingDots>().onBeatSpot)
        {
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }*/

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
            //StartCoroutine(nextPopUp());
            obstacle.SetActive(true);

            if (Time.timeScale == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

                    if (hit2D.collider.CompareTag("GreenDotU"))
                    {
                        StartCoroutine(nextPopUp());
                        Debug.Log("Vihreeseen osui!");
                        Time.timeScale = 1;
                        popUpIndex++;
                        PowerUp();
                        StartCoroutine(WaitTime());
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
        }

        else if (popUpIndex == 2)  // Turo added for 4th sign.
        {
            obstacle.SetActive(false);
            powerUpImage.SetActive(false);
            //StartCoroutine(FinalPopUp());
            if (Time.timeScale == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

                    if (hit2D.collider.CompareTag("GreenDotU"))
                    {
                        StartCoroutine(FinalPopUp());
                        Debug.Log("Vihreeseen osui!");
                        Time.timeScale = 1;
                        popUpIndex++;
                        StartCoroutine(WaitTime());
                    }
                    else
                    {
                        return;
                    }
                        
                }
            }

        }

        else if (popUpIndex == 3)
        {

            //StartCoroutine(FinalFinalPopup());
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(FinalFinalPopup());
                Time.timeScale = 1;
                    
            }
            
        }

        else if (popUpIndex == 4)
        {
            if (GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Combo>().attackCounter == 1)
            {
                arrow.SetActive(false);
                uDotsInGame.SetActive(false);
                spawner.SetActive(true);
                popUps[2].SetActive(false);
                Time.timeScale = 0;

            }
        }
        

       IEnumerator nextPopUp()
        {
            
            yield return new WaitForSeconds(2);
            popUpIndex = 2;
            //PowerUp();


        }
        IEnumerator FinalPopUp() // Turo added for 4th sign.
        {
            
            yield return new WaitForSeconds(2);
            popUpIndex = 3;
        }

        IEnumerator FinalFinalPopup()
        {
            yield return new WaitForSeconds(2);
            popUpIndex = 4;
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
