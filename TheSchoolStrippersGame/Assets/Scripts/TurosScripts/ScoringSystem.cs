using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    [SerializeField] TMP_Text scoreText;

    public int score;

    private void Update()
    {
        score = theScore;

        if(theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }

        scoreText.text = theScore.ToString();
    }
}
