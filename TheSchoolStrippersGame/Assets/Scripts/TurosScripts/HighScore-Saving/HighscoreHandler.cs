using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<HighScoreElemt> highscoreList = new List<HighScoreElemt>();
    [SerializeField] int maxCount = 5;
    [SerializeField] string fileName;

    public delegate void OnHighscoreListChanged(List<HighScoreElemt> list);
    public static event OnHighscoreListChanged onHighscoreListChanged;

    //List<InputEntry> entries = new List<InputEntry>();

    private void Start()
    {
        //entries = FileHandler.ReadFromJson<InputEntry>(fileName);
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadFromJson<HighScoreElemt>(fileName);

        while(highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }

        if(onHighscoreListChanged != null)
        {
            onHighscoreListChanged.Invoke(highscoreList);
        }
    }

    private void SaveHighscores()
    {
        FileHandler.SaveToJson<HighScoreElemt>(highscoreList, fileName);
    }

    public void AddHighscoreIfPossible(HighScoreElemt element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if(i >= highscoreList.Count || element.points > highscoreList[i].points)
            {
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                //FileHandler.SaveToJson<InputEntry>(entries, fileName);

                SaveHighscores();

                if (onHighscoreListChanged != null)
                {
                    onHighscoreListChanged.Invoke(highscoreList);
                }

                break;
            }
        }
    }
}
