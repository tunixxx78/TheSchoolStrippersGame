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
                Time.timeScale = 0;
                arrow.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    arrow.SetActive(false);
                    Time.timeScale = 1;
                    popUpIndex++;
                }
            }
        }
        else if (popUpIndex == 1)
        {
            StartCoroutine(nextPopUp());
            obstacle.SetActive(true);
            
        }
        else if (popUpIndex == 2)  // Turo added for 4th sign.
        {
            StartCoroutine(FinalPopUp());
            obstacle.SetActive(false);
            powerUpImage.SetActive(false);
            
            
        }
        else if (popUpIndex == 3)
        {
            if (GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Combo>().attackCounter == 1)
            {
                GameObject.Find("GameController").GetComponent<GameController>().WinLevel(3);
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
    }



}
