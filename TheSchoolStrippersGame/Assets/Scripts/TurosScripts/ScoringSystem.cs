using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    public static int thePoints;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float pointBarrier = 10f;

    public int score;
    public int points;

    private void Update()
    {
        score = theScore;
        points = thePoints;

        if (theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
        if (thePoints > PlayerPrefs.GetInt("PointCount", 0))
        {
            PlayerPrefs.SetInt("PointCount", thePoints);
        }

        scoreText.text = theScore.ToString();

        if (points >= pointBarrier)
        {
            points = 0;
        }
    }
}
