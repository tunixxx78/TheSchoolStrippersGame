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

    private int attackScore = 25;

    DestroyShip shipScript;

    [SerializeField]
    float wingameDelay = 5;

    // Turo Added
    public int bonusComboAmount = 5;


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
        // T?m? pit?? poistaa ------ vain devaajille ----------

        if (Input.GetKeyDown(KeyCode.Space))
        {
            current++;
            ModifyHealth();
        }

        if (current >= attackScore)
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
        if (current < attackScore)
        {
            current++;
            ModifyHealth();
        }
    }
    //Turo added -> adding extra point to combobar. Called from PointsPowerUp script.
    public void BonusComboBar()
    {
        current += bonusComboAmount;
        ModifyHealth();
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
            // kolme t?hte?
            if(ScoringSystem.theScore >= 5)
            {
                Invoke("ThreeStars", wingameDelay);
                /*
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
                */
                // deactive players and dots
                GameObject.Find("Player").SetActive(false);
                GameObject.Find("Spawners").SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().currentStarValue += 3;               
            }
            // kaksi t?hte?
            else if (ScoringSystem.theScore >= 3)
            {
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(true);
                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().currentStarValue += 2;
            }
            // yksi t?hti
            else if (ScoringSystem.theScore < 3)
            { 
                // active win scene and stars
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(2).gameObject.SetActive(true);
                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().currentStarValue += 1;
            }
            yield return new WaitForSeconds(wingameDelay);
        }
    }

    void ThreeStars()
    {
        // active win scene and stars
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
        
        
    }
}
