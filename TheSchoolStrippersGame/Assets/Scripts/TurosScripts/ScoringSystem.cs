using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    public static int thePoints;
    public static int theMultiplierPoints;
    [SerializeField] TMP_Text scoreText, scoreTextToWinScreen;
    public float pointBarrier = 1000f;
    [SerializeField] GameObject [] powerUpSpawnPoints;
    [SerializeField] GameObject powerUpItem;

    public int score;
    public int points;
    public int multiplierPoints;

    private void Start()
    {
        multiplierPoints = 0;

        theScore = 0;
        //PlayerPrefs.SetString("highscoreTable", 0.ToString());
        
    }

    private void Update()
    {
        score = theScore;
        points = thePoints;
        multiplierPoints = theMultiplierPoints;

        if (theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
        if (thePoints > PlayerPrefs.GetInt("PointCount", 0))
        {
            PlayerPrefs.SetInt("PointCount", thePoints);
        }
        if(theMultiplierPoints > PlayerPrefs.GetInt("MultiplierPointCount"))
        {
            PlayerPrefs.SetInt("MultiplierPointCount", theMultiplierPoints);
        }

        scoreText.text = theScore.ToString();
        scoreTextToWinScreen.text = theScore.ToString();

        if (thePoints >= pointBarrier)
        {
            thePoints = 0;
        }
    }

    public void SetPointsToZero()
    {
        score = theScore;
        theScore = 0;
        if (theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
    }

    public void PowerUpSpawn()
    {
        int randomSpawnPoints = Random.Range(0, powerUpSpawnPoints.Length);
        Instantiate(powerUpItem, powerUpSpawnPoints[randomSpawnPoints].transform.position, Quaternion.identity);
    }

    
}
