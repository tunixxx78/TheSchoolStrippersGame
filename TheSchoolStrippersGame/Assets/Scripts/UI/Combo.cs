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

    private int attackScore = 15;

    DestroyShip shipScript;

    [SerializeField]
    float wingameDelay = 5;

    // Turo Added
    public int bonusComboAmount = 500;
    public int bonusAddForCombobar = 1;
    [SerializeField] GameObject highscoreCanvas;
    public HighscoreHandler highscoreHandler;

    bool played = false;

    private float threeStars = 10000;
    private float twoStars = 5000;
    private float oneStar = 5000;

    private void Awake()
    {
        shipScript = FindObjectOfType<DestroyShip>();
    }
    private void Start()
    {
        mask.fillAmount = 0;
        highscoreHandler = FindObjectOfType<HighscoreHandler>();
        
    }
   
    void Update()
    {
        // Tama pitaa poistaa ------ vain devaajille ----------

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
        //current += bonusComboAmount;
        current += bonusAddForCombobar;
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
        PlayerPrefs.SetInt("Boolean", played ? 0 : 1);

        if (attackCounter == 4)
        {
            // kolme t?hte?
            if(ScoringSystem.theScore >= threeStars)
            {
                // Invoke lis?tty, ett? aikaa n?hd? laivan tuhoutuminen. Turo Lis?si.
                Invoke("ThreeStars", wingameDelay);
                highscoreHandler.LoadHighscores();
               
                // deactive players and dots
                GameObject.Find("Player").SetActive(false);
                GameObject.Find("Spawners").SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().WinLevel(3);
            }
            // kaksi t?hte?
            else if (ScoringSystem.theScore >= twoStars)
            {
                // Invoke lis?tty, ett? aikaa n?hd? laivan tuhoutuminen. Turo Lis?si.

                Invoke("TwoStars", wingameDelay);
                highscoreHandler.LoadHighscores();

                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().WinLevel(2);
            }
            // yksi t?hti
            else if (ScoringSystem.theScore < oneStar)
            {
                // Invoke lis?tty, ett? aikaa n?hd? laivan tuhoutuminen. Turo Lis?si.

                Invoke("OneStar", wingameDelay);
                highscoreHandler.LoadHighscores();

                // deactive players and dots
                GameObject.Find("Player").transform.gameObject.SetActive(false);
                GameObject.Find("Spawners").transform.gameObject.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().WinLevel(1);
            }
            yield return new WaitForSeconds(wingameDelay);
        }
    }

    void ThreeStars()
    {
        // active win scene and stars
        highscoreCanvas.SetActive(true);
    }

    void TwoStars()
    {
        highscoreCanvas.SetActive(true);
    }

    void OneStar()
    {
        highscoreCanvas.SetActive(true);
    }
}
