using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class HighScoreTable : MonoBehaviour
{
    

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    [SerializeField] int maxRowCount = 5;
    [SerializeField] TMP_Text playerPoints;
    

    int playerScore;

    private void Awake()
    {
        
        playerScore = ScoringSystem.theScore;
        playerPoints.text = playerScore.ToString();

        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        AddHighscoreEntry(playerScore);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j <highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score >highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
 
                }
                if (highscores.highscoreEntryList.Count > maxRowCount)
                {
                    highscores.highscoreEntryList.RemoveAt(maxRowCount);
                }

            }
        }
        
        

        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;

        }
        entryTransform.Find("PosText").GetComponent<TMP_Text>().text = rankString;

        
        int score = highscoreEntry.score;

        entryTransform.Find("ScoreText").GetComponent<TMP_Text>().text = score.ToString();

        
        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score)
    {
        
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score};

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;

                }
                /*while (highscores.highscoreEntryList.Count > maxRowCount)
                {
                    highscores.highscoreEntryList.RemoveAt(maxRowCount);
                }*/

            }
        }
        

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {

        public int score;

        

    }

}
