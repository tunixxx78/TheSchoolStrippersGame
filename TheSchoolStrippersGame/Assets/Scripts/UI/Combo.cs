using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combo : MonoBehaviour
{
    public int attackCounter = 0;

    public int maximum;
    public int current;
    public Image mask;

    DestroyShip shipScript;

    [SerializeField]
    float wingameDelay = 5;

    private void Awake()
    {
        shipScript = FindObjectOfType<DestroyShip>();
    }
    private void Start()
    {
        mask.fillAmount = 0;
    }
   
    void Update()
    {
        // Tämä pitää poistaa ------ vain devaajille ----------

        if (Input.GetKeyDown(KeyCode.Space))
        {
            current++;
            ModifyHealth();
        }

        if (current >= 25)
        {
            Attack();
            current = 0;
            ModifyHealth();
        }
        
    }

    public void ModifyHealth()
    {

        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void ComboBar()
    {
        if (current < 25)
        {
            current++;
            ModifyHealth();
        }
    }
    public void StartComboBar()
    {
        if (current > 0)
        {
            current--;
            ModifyHealth();
        }
    }

    public void Attack()
    {
        attackCounter += 1;

        //damage the ship through DestroyShip script
        shipScript.DamageShip(attackCounter);
        FindObjectOfType<SFXManager>().BreakingShip();
        
        StartCoroutine(WinGame());
    }

    public IEnumerator WinGame()
    {
        if(attackCounter == 4)
        {
            // kolme tähteä
            if(ScoringSystem.theScore >= 5)
            {
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
            }
            // kaksi tähteä
            else if (ScoringSystem.theScore >= 3)
            {
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(true);
                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
            }
            // yksi tähti
            else if (ScoringSystem.theScore < 3)
            { 
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(2).gameObject.SetActive(true);
                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(wingameDelay);
        }
    }
}
