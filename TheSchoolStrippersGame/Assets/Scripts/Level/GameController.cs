using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int levelIndex;
    public int currentStarValue;

    public void WinLevel(int _starNum)
    {
        currentStarValue = _starNum;

        Debug.Log("GGN if ulkopuolella" + currentStarValue + " stars + " + PlayerPrefs.GetInt("Lv" + levelIndex, _starNum));
        if (currentStarValue > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starNum);
            Debug.Log("Nyt ggn iffissä");
            Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starNum));
        }
    }
}
